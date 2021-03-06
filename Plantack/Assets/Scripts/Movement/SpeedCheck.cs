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
            {
                maxSpeed = Character.RunSpeed;
                anim.SetFloat("Running", 1);
            }
            else
            {
                maxSpeed = Character.WalkSpeed;
                anim.SetFloat("Running", 0);
            }
            return maxSpeed;
        }
        #endregion
    }
}