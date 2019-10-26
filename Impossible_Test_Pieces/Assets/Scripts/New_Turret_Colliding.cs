using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Turret_Colliding : MonoBehaviour
{
    public bool placeable;
    bool isColliding;
    bool canPlace;

    void Start()
    {
        isColliding = false;
    }

    void Update()
    {
        if(isColliding == false && canPlace == true)
        {
            placeable = true;
        }

        else
        {
            placeable = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CantPlace"))
        {
            isColliding = true;
        }

        if (other.CompareTag("CanPlace"))
        {
            canPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CantPlace"))
        {
            isColliding = false;
        }

        if (other.CompareTag("CanPlace"))
        {
            canPlace = false;
        }
    }
}
