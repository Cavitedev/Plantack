using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    #region
    private float acceleration = 0.015f;
    private float gravity = 9.81f;
    private float runSpeed = 6f;
    private float walkSpeed = 4f;
    private float dashSpeed = 12f;
    private float jumpForce = 3.5f;
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
    public float DashSpeed
    {
        get => dashSpeed;
    }
    public float JumpForce
    {
        get => jumpForce;
    }
    #endregion
}
