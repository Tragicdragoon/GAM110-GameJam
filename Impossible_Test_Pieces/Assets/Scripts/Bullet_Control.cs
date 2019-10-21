using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour
{
    public float speed;

    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(this.gameObject);
        }
    }
}
