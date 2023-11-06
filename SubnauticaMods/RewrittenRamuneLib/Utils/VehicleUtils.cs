

namespace RamuneLib.Utils
{
    public static class VehicleUtils
    {
        /// <summary>
        /// Retrieves an array of speed values for the Seaglide.
        /// </summary>
        /// <returns>An array containing the Seaglide speed values in the following order: forwardMaxSpeed, backwardMaxSpeed, strafeMaxSpeed, verticalMaxSpeed, waterAcceleration, swimDrag.</returns>
        public static float[] GetSeaglideSpeeds()
        {
            float[] values = null;

            values.Add(Player.main.playerController.seaglideForwardMaxSpeed);
            values.Add(Player.main.playerController.seaglideBackwardMaxSpeed);
            values.Add(Player.main.playerController.seaglideStrafeMaxSpeed);
            values.Add(Player.main.playerController.seaglideVerticalMaxSpeed);
            values.Add(Player.main.playerController.seaglideWaterAcceleration);
            values.Add(Player.main.playerController.seaglideSwimDrag);

            return values;
        }

        /// <summary>
        /// Retrieves an array of speed values set on the provided vehicle component.
        /// </summary>
        /// <returns>An array containing the values set on the provided vehicle component in the following order: forwardForce, backwardForce, sidewardForce, verticalForce.</returns>
        public static float[] GetVehicleSpeeds(Vehicle vehicle)
        {
            float[] values = null;

            values.Add(vehicle.forwardForce);
            values.Add(vehicle.backwardForce);
            values.Add(vehicle.sidewardForce);
            values.Add(vehicle.verticalForce);

            return values;
        }


        public static void MultiplyVehicleSpeeds(this Vehicle vehicle, float multiplier)
        {
            vehicle.forwardForce *= multiplier;
            vehicle.backwardForce *= multiplier;
            vehicle.sidewardForce *= multiplier;
            vehicle.verticalForce *= multiplier;
        }


        public static void MultiplyVehicleSpeeds(this Vehicle vehicle, float multiplier, float duration)
        {
            CoroutineHost.StartCoroutine(MultiplyVehicleSpeedsAsync(vehicle, multiplier, duration));
        }

        private static IEnumerator MultiplyVehicleSpeedsAsync(Vehicle vehicle, float multiplier, float duration)
        {
            float[] originals = GetVehicleSpeeds(vehicle);

            vehicle.forwardForce *= multiplier;
            vehicle.backwardForce *= multiplier;
            vehicle.sidewardForce *= multiplier;
            vehicle.verticalForce *= multiplier;

            yield return new WaitForSeconds(duration);

            vehicle.forwardForce *= originals[0];
            vehicle.backwardForce *= originals[1];
            vehicle.sidewardForce *= originals[2];
            vehicle.verticalForce *= originals[3];

            // Not tested yet, dunno if this shit works
        }
    }
}