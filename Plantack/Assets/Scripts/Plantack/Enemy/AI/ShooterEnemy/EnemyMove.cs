using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    Transform shootPoint;
    Rigidbody2D rb;


    Quaternion rot;
    public bool Engaged;
    public float Speed;
    public float stoppingDist;
    public float retreatDist;

    // Start is called before the first frame update
    void Start()
    {
        shootPoint = transform.GetChild(0);
        rot = new Quaternion (0,0,0,1);
        Speed = 1f;
        retreatDist = 2f;
        stoppingDist = 3f;
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
                Move(-Speed, true);
            }
            else
            {
                Move(0f, false);
            }
        }
    }
    private float GetDistance()
    {
        return Vector2.Distance(shootPoint.position, player.position);
    }
    private void Move(float Speed, bool towards)
    {
        Vector2 moveDir = (player.transform.position - shootPoint.position).normalized * Speed;
        rb.velocity = moveDir;

        if (!towards)
        {
            shootPoint.transform.LookAt(player);
            if (moveDir.x < 0 && transform.localScale.x != -1)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (moveDir.x > 0 && transform.localScale.x != 1)
                transform.localScale = new Vector3(1, 1, 1);

            if (shootPoint.transform.rotation.z > -0.25f && shootPoint.transform.rotation.z < 0.25f)
            {
                rot = shootPoint.rotation;
                rot.y = 0.0f;
                rot.x = 0.0f;
                transform.rotation = rot;
            }
        }
    }
}
