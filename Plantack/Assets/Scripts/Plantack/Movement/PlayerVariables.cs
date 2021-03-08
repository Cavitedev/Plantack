namespace Plantack.Movement
{
    public class PlayerVariables
    {
        #region
        private float acceleration = 0.015f;
        private float gravity = -9.81f;
        private float runSpeed = 4f;
        private float walkSpeed = 2f;
        private float climbSpeed = 5f;
        private float jumpForce = 5f;
        private float speedError = 0.05f;
        #endregion

        #region Variable Calls
        public float Acceleration
        {
            get => acceleration;
        }
        public float Gravity
        {
            get => gravity;
        }
        public float RunSpeed
        {
            get => runSpeed;
        }
        public float WalkSpeed
        {
            get => walkSpeed;
        }
        public float ClimbSpeed
        {
            get => climbSpeed;
        }
        public float JumpForce
        {
            get => jumpForce;
        }
        public float SpeedError
        {
            get => speedError;
        }
        #endregion
    }
}
