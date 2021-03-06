using UnityEngine;
namespace Plantack.PlayerController
{
    [RequireComponent(typeof(GetInput), typeof(SpeedCheck))]
    public class BasicMovement : MonoBehaviour
    {
        #region Variables
        GetInput input;
        PlayerVariables Character;
        SpeedCheck speedCheck;

        private float maxSpeed, moveSpeed, FallForce, gravity;
        private Vector3 Xdir, Ydir;
        #endregion
        void Start()
        {
            input = gameObject.GetComponent<GetInput>();
            Character = new PlayerVariables();
            speedCheck = gameObject.GetComponent<SpeedCheck>();
        }
        
        public void Activate()
        {
            Xdir = GetX(input);
            maxSpeed = speedCheck.Activate(input, Character);
            FallForce = 
        }
        private Vector3 GetX(GetInput input)
        {
            Vector3 Xdir = Vector3.zero;
            Xdir.x = input.Basic;
            return Xdir;
        }
    }
}