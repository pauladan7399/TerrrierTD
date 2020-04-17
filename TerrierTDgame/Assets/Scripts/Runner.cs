using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;
    private Waypoints Wpoints;

    private int waypointIndex;

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    public void TakeDamage(int amount){
        health -= amount;
        if (health <= 0){
            Die();
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
