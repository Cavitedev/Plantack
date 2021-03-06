using UnityEngine;
namespace Plantack.PlayerController
{
    public class SpeedCheck : MonoBehaviour
    {
        #region Variables
        bool running;
        #endregion

        #region Speed Checker
        public float Activate(GetInput input, PlayerVariables Character)
        {
            float maxSpeed;
            if (input.Run)
                running = !running;
            if (running)
                maxSpeed = Character.RunSpeed;
            else
                maxSpeed = Character.WalkSpeed;

            return maxSpeed;
        }
        #endregion
    }
}