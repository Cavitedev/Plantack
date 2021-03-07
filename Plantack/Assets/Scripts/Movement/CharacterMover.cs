using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    #region
    Animator anim;
    Rigidbody2D rb;
    PlayerVariables Character;

    Vector2 XYdir;
    Quaternion rot;
    bool ladder, moveR, moveL;
    #endregion

    private void Start()
    {
        anim = transform.Find("Player").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Character = new PlayerVariables();
    }
    private void FixedUpdate()
    {
        rb.velocity = XYdir;
        XYdir = Vector2.zero;
        Gravity();
        MoveRight();
        MoveLeft();
        transform.rotation = rot;
    }
    #region MoveLeft
    public void moveLon() => moveL = true;
    public void moveLoff() => moveL = false;
    public void MoveLeft()
    {
        if (!ladder && moveL)
        {
            XYdir.x = -1;
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
        if (!ladder && moveR)
        {
            XYdir.x = 1;
            rot.y = 0f;
            Debug.Log("Clicked Right");
        }
    }
    #endregion
    void Gravity()
    {
        XYdir.y = rb.velocity.y;
    }
    public void Climb()
    {
        if (!ladder)
        {
            XYdir.y = 1;
        }
        else
        {

        }
        }
}