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
        transform.rotation = rot;
    }
    public void MoveLeft()
    {
        XYdir.x = -1;
        rot.y = 180f;
        Debug.Log("Clicked Left");
    }
    public void MoveRight()
    {
        XYdir.x = 1;
        rot.y = 0f;
        Debug.Log("Clicked Right");

    }
    public void Climb()
    {
        XYdir.y = 1;
    }
}