using UnityEngine;
namespace Plantack.PlayerController
{
    public class SpeedCheck : MonoBehaviour
    {
        #region Variables
        bool running;
        #endregion

        #region Speed Checker
        public float Activate(GetInput input, PlayerVariables Character, Animator anim)
        {
            float maxSpeed;
            if (input.Run)
                running = !running;
            if (running)
                maxSpeed = Character.RunSpeed;
            else
                maxSpeed = Character.WalkSpeed;
            anim.SetBool("Running", running);
            return maxSpeed;
        }
        #endregion
    }
}