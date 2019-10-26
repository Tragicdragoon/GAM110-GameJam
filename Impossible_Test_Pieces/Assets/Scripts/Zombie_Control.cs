using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Control : MonoBehaviour
{
    public float speed;
    public float newSpeed;
    float timeSpeed;
    public float health;
    float healthLost;
    Transform target;
    public GameObject nodes;
    Rigidbody zombie;
    public GameObject spawnPoint;
    public bool isStunned;
    float stunCoolDown;
    float burnTime;
    bool onFire;
    int currentNode;

    void Start()
    {
        zombie = this.GetComponent<Rigidbody>();
        healthLost = 0;
        stunCoolDown = 1.0f;
        burnTime = 0.3f;
        currentNode = 0;
        target = nodes.transform.GetChild(currentNode).transform;
    }

    void Update()
    {
        if (speed < 7)
        {
            timeSpeed = Time.fixedTime / 100;
        }

        newSpeed = speed - (healthLost / 10) + timeSpeed;
        Vector3 direction = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(direction);

        if (isStunned == true)
        {            
            zombie.velocity = Vector3.zero;

            stunCoolDown -= Time.deltaTime;
            if (stunCoolDown <= 0)
            {
                isStunned = false;
                stunCoolDown = 1.0f;
            }
        }

        if (isStunned == false)
        {
            zombie.velocity = transform.forward * newSpeed;            
        }

        if (onFire == true)
        {
            burnTime -= Time.deltaTime;

            if (burnTime <= 0)
            {
                health -= 0.1f;
                burnTime = 0.3f;
            }
        }

        if (health <= 0)
        {
            spawnPoint.GetComponent<Zombie_Spawning>().zombies.Remove(this.gameObject);
            spawnPoint.GetComponent<Score>().MediumZombie();
            spawnPoint.GetComponent<Turret_Spawner>().resources +=3;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Bullet"))
        {
            health -= 1;
            healthLost += 1;
        }

        if (hit.CompareTag("Blast"))
        {
            health -= 3;
            healthLost += 3;
        }

        if (hit.CompareTag("Pulse"))
        {
            isStunned = true;
        }

        if (hit.CompareTag("Fire"))
        {
            health -= 0.1f;
            onFire = true;
        }
        
        if (hit.CompareTag("Node"))
        {
            if ((currentNode + 2) <= nodes.transform.childCount)
            {
                currentNode += 1;
                target = nodes.transform.GetChild(currentNode).transform;
            }
        }
    }
}