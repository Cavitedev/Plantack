using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Shooting Vars
    public float targetRange = 5f;
    float shootTimer = 0.25f;
    float reloadTimer = 2f;
    float deleteTimer = 5f;
    bool canShoot = true;
    bool hasAmmo;
    bool reloading;
    int ammo;
    int maxAmmo = 10;
    List<GameObject> bullets;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    #endregion
    public float distance;
    Vector2 Direction;
    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public Rigidbody2D rb;
    public LayerMask layer;
    public Transform player;

    private void Start()
    {
        shootPoint = transform.GetChild(0);
        rb = transform.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        for (int i = 0; i< maxAmmo; i++)
        {
            Debug.Log(i + " Bullet Added");
            GameObject bullet =  Instantiate(bulletPrefab, shootPoint.position, transform.rotation, transform);
            bullets.Add(bullet);
            bullet.SetActive(false);
        }
    }

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        castRay();
    }
    private float GetDistance(Transform player)
    {
        return Vector2.Distance(transform.position, player.position);
    }

    #region Shoot
    private void castRay()
    {
        Debug.DrawRay(shootPoint.position, -transform.right*targetRange, Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, -transform.right, targetRange, layer);
        
        if (hit)
        {
            CheckAmmo();
            Shoot(hit);
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
}
