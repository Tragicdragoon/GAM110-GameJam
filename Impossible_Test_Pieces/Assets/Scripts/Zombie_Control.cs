using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Control : MonoBehaviour
{
    public float speed;
    float newSpeed;
    public int health;
    float healthLost;
    Transform target;
    Rigidbody zombie;
    public GameObject spawnPoint;

    void Start()
    {
        zombie = this.GetComponent<Rigidbody>();
        healthLost = 0;
        target = spawnPoint.GetComponent<Zombie_Spawning>().target;
    }

    void Update()
    {
        newSpeed = speed - healthLost;

        Vector3 direction = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(direction);
        zombie.velocity = transform.forward * newSpeed;
    }

    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag("Bullet"))
        {
            health -= 1;
            healthLost += 0.5f;

            if (health <= 0)
            {
                spawnPoint.GetComponent<Zombie_Spawning>().zombies.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}