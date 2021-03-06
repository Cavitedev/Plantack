using UnityEngine;
namespace Plantack.PlayerController
{
    [RequireComponent(typeof(GetInput), typeof(SpeedCheck), typeof(GetDir))]
    public class BasicMovement : MonoBehaviour
    {
        #region Variables
        Rigidbody2D rb;
        GetInput input;
        PlayerVariables Character;
        SpeedCheck speedCheck;
        GetDir getDir;

        private float maxSpeed, moveSpeed, FallForce, gravity;
        private Vector3 XYdir;
        #endregion
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<GetInput>();
            Character = new PlayerVariables();
            speedCheck = GetComponent<SpeedCheck>();
            getDir = GetComponent<GetDir>();
        }

        private void FixedUpdate()
        {
            Activate();
        }
        public void Activate()
        {
            XYdir = getDir.Activate(input, Character, rb);
            maxSpeed = speedCheck.Activate(input, Character);
            rb.velocity = XYdir;
        }       
        
    }
}