using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Attack : MonoBehaviour
{
    public float speed;
    Transform target;
    public GameObject blast;

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
            Instantiate(blast, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
