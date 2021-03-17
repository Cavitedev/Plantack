using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    #region Shooting Vars
    public float targetRange = 5f;
    float shootTimer = 1f;
    float reloadTimer = 2f;
    float deleteTimer = 6f;
    bool canShoot = true;
    bool hasAmmo;
    bool reloading;
    int ammo;
    int maxAmmo = 10;
    List<GameObject> bullets = new List<GameObject>();

    public GameObject bulletPrefab;
    public Transform shootPoint;
    #endregion
    public float distance;
    Vector2 Direction;
    public Rigidbody2D rb;
    public LayerMask layer;
    public Transform player;
    Animator anim;

    Vector3 rot;
    public bool Engaged;
    public bool turned;
    public float movSpeed = 2f;
    public float retSpeed = 0.5f;
    public float stoppingDist = 3f;
    public float retreatDist = 2f;
    public float EngageDist = 7f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rot = new Vector3(0, 0, 0);

        shootPoint = transform.GetChild(0);
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        for (int i = 0; i< maxAmmo; i++)
        {
            GameObject bullet =  Instantiate(bulletPrefab, shootPoint.position, transform.rotation, transform.parent);
            bullets.Add(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Mover();
        castRay();
    }    

    #region Shoot
    private void castRay()
    {
        if (GetDistance() < targetRange)
        {
            Debug.DrawRay(shootPoint.position, -transform.right * targetRange, Color.yellow);
            RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, (player.transform.position - shootPoint.position).normalized, targetRange, layer);
            if (hit)
            {
                CheckAmmo();
                Shoot(hit);
            }
        }
    }
    private void Shoot(RaycastHit2D target)
    {
        if (canShoot && hasAmmo)
        {
            bullets[ammo-1].transform.position = shootPoint.position;
            bullets[ammo-1].SetActive(true);
            StartCoroutine(DisableBullet(bullets[ammo - 1]));
            canShoot = false;
            StartCoroutine(ShootTimer());
            ammo -= 1;
            anim.SetTrigger("Attack");

        }
        else if (canShoot && !hasAmmo && !reloading)
        {
            StartCoroutine(Reload());
        }
    }
    void CheckAmmo()
    {
        if (ammo < 1)
            hasAmmo = false;
        else
            hasAmmo = true;
    }
    IEnumerator Reload()
    {
        reloading = true;
        float endTimer = Time.time + reloadTimer;
        while (Time.time < endTimer)
        {
            yield return null;
        }
        ammo = maxAmmo;
        reloading = false;
    }
    IEnumerator ShootTimer()
    {
        float endTimer = Time.time + shootTimer;
        while (Time.time < endTimer)
        {
            yield return null;
        }
        canShoot = true;
    }
    IEnumerator DisableBullet(GameObject bullet)
    {
        float endTimer = Time.time + deleteTimer;
        while (Time.time < endTimer)
        {
            yield return null;
        }
        bullet.SetActive(false);
    }
    #endregion

    #region Move

    private void Mover()
    {
        if (!Engaged && GetDistance() <= EngageDist)
            Engaged = true;
        else if (Engaged && GetDistance() > EngageDist)
            Engaged = false;
        if (Engaged)
        {
            if (GetDistance() > stoppingDist)
            {
                Move(movSpeed, true);
            }
            else if (GetDistance() <= retreatDist)
            {
                Move(-retSpeed, true);
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
        anim.SetFloat("Movement", moveDir.sqrMagnitude);
        if (towards)
        {
            if (transform.position.x < player.position.x && !turned)
            {
                rot.y = 180f;
                turned = true;
            }
            else if (transform.position.x > player.position.x && turned)
            {
                rot.y = 0f;
                turned = false;
            }
            transform.eulerAngles = rot;
        }
    }
    #endregion
}
