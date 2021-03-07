using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(PlayerVariables))]
public class CharacterMover : MonoBehaviour
{
    #region
    Animator anim;
    Rigidbody2D rb;
    PlayerVariables Character;
    Button runButton;

    Vector2 XYdir;
    Quaternion rot;
    bool isGrounded, running, climbing, ladder, moveR, moveL;
    float maxSpeed, fallForce, gravity;

    #region GroundCheck
    public Transform feetPos;
    public float checkRadius = 0.3f;
    public LayerMask whatIsGround;
    #endregion
    #endregion

    private void Start()
    {
        feetPos = transform.Find("feetPos").transform;
        anim = transform.Find("Player").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Character = new PlayerVariables();

        gravity = Character.Gravity;
    }
    private void FixedUpdate()
    {
        rb.velocity = XYdir;
        XYdir = Vector2.zero;
        SetSpeed();
        MoveRight();
        MoveLeft();
        Climb();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        transform.rotation = rot;
        FallForce();
        Animate();
    }

    void Animate()
    {
        anim.SetFloat("Movement", Mathf.Abs(XYdir.x));
        anim.SetBool("Running", running);
        anim.SetBool("Climbing", climbing);
    }
    #region MoveLeft
    public void moveLon() => moveL = true;
    public void moveLoff() => moveL = false;
    public void MoveLeft()
    {
        if (!climbing && moveL)
        {
            XYdir.x = -1 * maxSpeed;
            rot.y = 180f;
            Debug.Log("Clicked Left");
        }
    }
    #endregion

    #region MoveRight
    public void moveRon() => moveR = true;
    public void moveRoff() => moveR = false;
    private void MoveRight()
    {
        if (!climbing && moveR)
        {
            XYdir.x = 1 * maxSpeed;
            rot.y = 0f;
            Debug.Log("Clicked Right");
        }
    }
    #endregion

    #region Jump
    void FallForce()
    {
        if (fallForce < gravity)
            fallForce = gravity;
        else if (fallForce > gravity)
            fallForce += gravity * Time.deltaTime;
        XYdir.y = fallForce;
    }
    public void Jump()
    {
        if (!climbing && isGrounded)
        {
            fallForce = Character.JumpForce;
            anim.SetTrigger("Jump");
            Debug.Log("Has Jumped");
        }
    }
    #endregion

    #region Climb
    public void ClimbON() => climbing = true;
    public void ClimbOFF() => climbing = false;
    private void Climb()
    {
        if (climbing && ladder)
        {
            XYdir.y = Character.ClimbSpeed;
            Debug.Log("Climbing");
        }
    }
    #endregion

    #region Run/Walk
    public void Run()
    {
        running = !running;
    }
    public void SetSpeed()
    {
        if (running)
            maxSpeed = Character.RunSpeed;
        else
            maxSpeed = Character.WalkSpeed;
        anim.SetBool("Running", running);
    }
    #endregion

}