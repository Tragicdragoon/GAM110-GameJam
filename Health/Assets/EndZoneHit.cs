using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    public float health = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
            Destroy(other.gameObject);

            if (health < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
