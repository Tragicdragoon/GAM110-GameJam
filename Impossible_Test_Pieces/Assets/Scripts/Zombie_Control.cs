using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Control : MonoBehaviour
{
    public float speed;
    public float newSpeed;
    public int health;
    float healthLost;
    public Transform target;
    Rigidbody zombie;

    void Start()
    {
        zombie = this.GetComponent<Rigidbody>();
        healthLost = 0;
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
                Destroy(this.gameObject);
            }
        }
    }
}