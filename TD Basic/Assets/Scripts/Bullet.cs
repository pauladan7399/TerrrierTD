using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 35f;
    public int damage = 1;
    public GameObject impactEffect;
    //public Runner runner;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position; 
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget () 
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        //Destroy(target.gameObject);
        //runner.TakeDamage(damage);

        Runner r = target.GetComponent<Runner>();
        r.TakeDamage(damage);

        Destroy(gameObject);
    }
    //void DoDamage(transform Runner){
     //   Runner r  = Runner.GetComponent<Enemy>();  ?????

    //}
}
