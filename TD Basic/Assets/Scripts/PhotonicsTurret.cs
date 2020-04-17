using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonicsTurret : MonoBehaviour
{
    public Transform target;


    [Header("Attributes")]
    public float range = 3f;
    public float fireRate = 15f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string runnerTag = "Runner";

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] runners = GameObject.FindGameObjectsWithTag(runnerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestRunner = null;
        foreach (GameObject runner in runners)
        {
            float distanceToRunner = Vector2.Distance(transform.position, runner.transform.position);
            if (distanceToRunner < shortestDistance)
            {
                shortestDistance = distanceToRunner;
                nearestRunner = runner;
            }
        }
        if (nearestRunner != null && shortestDistance <= range)
        {
            target = nearestRunner.transform;
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
