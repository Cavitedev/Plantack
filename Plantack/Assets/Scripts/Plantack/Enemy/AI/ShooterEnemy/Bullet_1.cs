using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_1 : MonoBehaviour
{
    GameObject target;
    public float speed, timer;
    Rigidbody2D rb;

    void Start()
    {
        Debug.Log(gameObject.name + " enabled");
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = moveDir;
    }
}
