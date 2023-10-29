

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
        /// Retrieves an array of speed values for the Seamoth.
        /// </summary>
        /// <returns>An array containing the Seamoth speed values in the following order: forwardForce, backwardForce, sidewardForce, verticalForce.</returns>
        public static float[] GetSeamothSpeeds()
        {
            var vehicle = Player.main.GetVehicle();

            if(vehicle.GetType() != typeof(SeaMoth))
                return null;

            float[] values = null;

            values.Add(vehicle.forwardForce);
            values.Add(vehicle.backwardForce);
            values.Add(vehicle.sidewardForce);
            values.Add(vehicle.verticalForce);

            return values;
        }

        /// <summary>
        /// Retrieves an array of speed values for the Exosuit.
        /// </summary>
        /// <returns>An array containing the Exosuit speed values in the following order: forwardForce, backwardForce, sidewardForce, verticalForce.</returns>
        public static float[] GetExosuitSpeeds()
        {
            var vehicle = Player.main.GetVehicle();

            if(vehicle.GetType() != typeof(Exosuit))
                return null;

            float[] values = null;

            values.Add(vehicle.forwardForce);
            values.Add(vehicle.backwardForce);
            values.Add(vehicle.sidewardForce);
            values.Add(vehicle.verticalForce);

            return values;
        }
    }
}