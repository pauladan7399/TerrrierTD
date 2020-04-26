using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 35f;
    public float splashRadius = 0f;
    public float slowEffectDuration = 0f;
    public float poisonEffectDamage = 0f;
    public float damage = 1;
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
        if (splashRadius > 0)
        {
            Explode();
        }
        else
        {
            DoDamage(target);
        }
        Destroy(gameObject); //destory bullet
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Runner")
            {
                DoDamage(collider.transform);
            }
        }
    }

    void DoDamage(Transform runner){
        Runner r = runner.GetComponent<Runner>();
        r.TakeDamage(damage);
        if (slowEffectDuration > 0)
            r.StartSlow(slowEffectDuration);
        if (poisonEffectDamage > 0)
            r.StartPoison(poisonEffectDamage);
    }
}
