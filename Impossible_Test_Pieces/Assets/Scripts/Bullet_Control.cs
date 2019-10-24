using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour
{
    public float speed;
    Transform target;

    void Start()
    {
        target = GetComponentInParent<Turret_Control>().target;
        transform.LookAt(target);
    }

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
