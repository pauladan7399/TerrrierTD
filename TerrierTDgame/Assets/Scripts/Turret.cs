using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer sprite;

    [Header("General")]
    public float range = 5f;
    public float fireRate = 5f;
    private float fireCountdown = 0f;
    public int id = 1;
    public int level = 1;

    //[Header("Use Bullets (default)")]


    //[Header("Use Laser")]         //To be used once we implement laser turret
    //public int damageOverTime = 10f;

    [Header("Unity Setup Fields")]
    public string runnerTag = "Runner";

    public GameObject bulletPrefab;
    public Transform firePoint;
   
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        sprite = GetComponent<SpriteRenderer>();
    }

    void UpdateTarget () 
    {
        GameObject[] runners = GameObject.FindGameObjectsWithTag(runnerTag);
        //float shortestDistance = Mathf.Infinity;
        float shortestDistance = Mathf.Infinity;
        float largestDistanceZ = -9999;
        //GameObject nearestRunner = null;
        GameObject firstRunner = null;
        foreach (GameObject runner in runners) 
        {
            float distanceToRunner = Vector2.Distance(transform.position, runner.transform.position);
            float distanceToRunnerZ = transform.position.z - runner.transform.position.z;
            //if (distanceToRunner > shortestDistance) 
            if (distanceToRunnerZ > largestDistanceZ)
            {
                if (distanceToRunner < range) {
                    shortestDistance = distanceToRunner;
                    largestDistanceZ = distanceToRunnerZ;
                    firstRunner = runner;
                }
                //nearestRunner = runner;
            }

        }
        //if (nearestRunner != null && shortestDistance <= range)
        if (firstRunner != null && shortestDistance <= range)
        {
            //target = nearestRunner.transform;
            target = firstRunner.transform;
        } else 
        {
            target = null;
        }

    }
    void Update ()
    {
        if (target == null) {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/ fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot () 
    {
        GameObject baseBullet = (GameObject)Instantiate(bulletPrefab); //creating base bullet to reference 
        Bullet BB = baseBullet.GetComponent<Bullet>();
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>(); //Actual Bullet Object being used
        if (level == 2) {
            bullet.damage = BB.damage*1.2f; //Upgrading damage to Level 2
        }
        if(level == 3) {
            bullet.damage = BB.damage*1.45f; //Upgrading damage to level 3
        }
        
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void onDrawGizmosSelected () 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public int getId() {
        return id;
    }

    public void Upgrade() {
        level++;
        float up = 1.2f;
        if (level == 2) {
            sprite.color = new Color(0.65f, 0.85f, 1f, 1f); //Blueish silver (level 2)
        }
        if (level ==3) {
            sprite.color = new Color(1f, 0.9f, 0.1f, 1f); //color for gold (level 3)
        }
        range = range*up; //increasing range of tower
        fireRate = fireRate*up; //increasing firerate
        
        
    }

}
