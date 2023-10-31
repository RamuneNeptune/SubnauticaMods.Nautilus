

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
    }
}