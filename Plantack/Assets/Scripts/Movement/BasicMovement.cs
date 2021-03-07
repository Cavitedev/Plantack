using UnityEngine;
namespace Plantack.PlayerController
{
    [RequireComponent(typeof(GetInput), typeof(SpeedCheck), typeof(GetDir))]
    public class BasicMovement : MonoBehaviour
    {
        #region Variables
        Animator anim;
        Rigidbody2D rb;
        GetInput input;
        PlayerVariables Character;
        SpeedCheck speedCheck;
        GetDir getDir;

        [SerializeField]
        private float maxSpeed, moveSpeed, FallForce, gravity;
        [SerializeField]
        private Vector2 XYdir;
        private Quaternion rot;
        #endregion
        void Start()
        {
            anim = transform.Find("Player").GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<GetInput>();
            Character = new PlayerVariables();
            speedCheck = GetComponent<SpeedCheck>();
            getDir = GetComponent<GetDir>();

            gravity = Character.Gravity;

        }

        private void Update()
        {
            Activate();
        }
        public void Activate()
        {
            XYdir = getDir.Activate(input, Character, rb);
            anim.SetFloat("Movement", Mathf.Abs(XYdir.x));
            GetRot();
            maxSpeed = speedCheck.Activate(input, Character, anim);
            moveSpeed = getSpeed(moveSpeed, maxSpeed);
            JumpOn();
            fallForce();
            GetDirection();
            rb.velocity = XYdir;
        }
        float getSpeed(float moveSpeedm, float maxSpeed)
        {
            if (moveSpeed < maxSpeed - Character.SpeedError)
                moveSpeed += Character.Acceleration;
            else if (moveSpeed > maxSpeed + Character.SpeedError)
                moveSpeed -= Character.Acceleration;
            return moveSpeed;
        }
        void JumpOn()
        {
            if (input.Jump)
            {
                FallForce = Character.JumpForce;
                anim.SetTrigger("Jump");
            }
        }
        void fallForce()
        {
            if (FallForce < gravity)
                FallForce = gravity;
            else if (FallForce > gravity)
                FallForce += gravity * Time.deltaTime;
        }
        void GetDirection()
        {
            XYdir.x = XYdir.x * moveSpeed;
            XYdir.y = XYdir.y * FallForce;
        }
        void GetRot()
        {
            if (input.Basic > 0)
                rot.y = 0f;
            else if (input.Basic < 0)
                rot.y = 180f;
            transform.rotation = rot;
        }
    }
}