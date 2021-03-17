using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;

    Quaternion rot;
    public bool Engaged;
    public float Speed;
    public float stoppingDist;
    public float retreatDist;

    // Start is called before the first frame update
    void Start()
    {
        rot = new Quaternion (0,0,0,1);
        Speed = 1f;
        retreatDist = 3f;
        stoppingDist = 5f;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    private void Mover()
    {
        if (Engaged)
        {
            if (GetDistance() > stoppingDist)
            {
                Move(Speed, true);
            }
            else if (GetDistance() <= retreatDist)
            {
                Move(-Speed, false);
            }
            else
            {
                Move(0f, false);
            }
        }
    }
    private float GetDistance()
    {
        return Vector2.Distance(transform.position, player.position);
    }
    private void Move(float Speed, bool towards)
    {
        Vector2 moveDir = (player.transform.position - transform.position).normalized * Speed;
        rb.velocity = moveDir;
        if (!towards)
        {
            if (moveDir.x < 0 && rot.y != 180)
            {
                rot.y = 180f;
                transform.rotation = rot;
            }
            else if (moveDir.x > 0 && rot.y != 0)
            {
                rot.y = 0f;
                transform.rotation = rot;
            }
        }
    }
}
