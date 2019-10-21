using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Turret_Colliding : MonoBehaviour
{
    public bool isColliding;

    void Start()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CantPlace"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
