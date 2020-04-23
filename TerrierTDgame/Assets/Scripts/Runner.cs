using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed;
    public float health;
    public int damage;
    public bool isSlowed = false;
    public bool isPoisoned = false;
    private Waypoints Wpoints;
    public SpriteRenderer sprite;

    private int waypointIndex;

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        sprite = GetComponent<SpriteRenderer>(); //accessing SpriteRenderer
    }

    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0){
            Die();
        }
    }

    public void StartSlow(float duration)
    {
        StartCoroutine(Slow(duration));
    }
    public IEnumerator Slow(float duration)
    {
        sprite.color = new Color(0, 1, 1, 1); //Changes color of sprite when slowed
        if (isSlowed == false) //If runner is already slowed, it can't slow down more
        {
            speed = speed / 2;
            isSlowed = true;
            yield return new WaitForSeconds(duration);
            sprite.color = new Color(1, 1, 1, 1); //Changes color back
            speed = speed * 2; //set speed back to normal
            isSlowed = false;
        }
    }

    public void StartPoison(float poisonDamage)
    {
        StartCoroutine(Poison(poisonDamage));
    }
    public IEnumerator Poison(float poisonDamage)
    {
        if (isPoisoned == false) //If runner is already slowed, it can't slow down more
        {
            isPoisoned = true;
            Debug.Log("POISONED");
            for (float i = 0; i <= poisonDamage; i++)
            {
                yield return new WaitForSeconds(0.4f);
                sprite.color = new Color(0, 1, 0, 1); //Changes color
                TakeDamage(1);
                yield return new WaitForSeconds(0.1f);
                sprite.color = new Color(1, 1, 1, 1); //Changes color back
            }
            isPoisoned = false;
        }
    }

    void Die(){
        Destroy(gameObject);
        //add in cool effects
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime); //moving the sprite

        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position; //to orient the runner sprite
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270){  
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //If the sprite is upsidedown, Then it will flip and face the opposite direction
        }
        else{
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }


        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f) {
            if (waypointIndex < Wpoints.waypoints.Length -1) {
                waypointIndex++;
            }
            else {
                EndPath();
                return;
            }
        }
    }

    void EndPath ()
    {
        Destroy(gameObject);
        PlayerStats.Lives -= damage;
        Debug.Log(PlayerStats.Lives);

    }
}
