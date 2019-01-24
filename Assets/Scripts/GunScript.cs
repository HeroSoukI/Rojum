using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float fireRate = 0;
    public LayerMask whatToHit;
    float timeToFire = 0;
    public Transform firePoint;
    public Transform bulletTrailPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        firePoint = transform.Find ("firePoint");
        if (firePoint == null)
        {
            Debug.Log("kd o firepoint carai"); 
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Effect();
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

    void Effect()
    {
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
    }

}
