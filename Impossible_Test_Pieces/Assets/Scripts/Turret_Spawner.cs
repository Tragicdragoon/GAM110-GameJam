using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Spawner : MonoBehaviour
{
    public GameObject fakeTurret;
    public GameObject turret;
    GameObject newTurret;
    Vector2 mousePos;
    Ray pointingAt;
    bool placeTurret;
    bool isColliding;
    
    void Update()
    {
        if (placeTurret == true)
        {
            isColliding = newTurret.GetComponent<New_Turret_Colliding>().isColliding;

            mousePos = Input.mousePosition;
            pointingAt = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if (Physics.Raycast(pointingAt, out hit))
            {
                newTurret.transform.position = hit.point;
                newTurret.transform.position = new Vector3(newTurret.transform.position.x, 0.5f, newTurret.transform.position.z);
            }

            if (Input.GetMouseButtonDown(0) && isColliding == false)
            {
                GameObject placedTurret = Instantiate(turret, newTurret.transform.position, newTurret.transform.rotation);
                Destroy(newTurret);
                placedTurret.GetComponent<Turret_Control>().spawner = gameObject;
                placeTurret = false;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(newTurret);
                placeTurret = false;
            }
        }
    }

    public void CreateTurret()
    {
        if (newTurret != null)
        {
            Destroy(newTurret);
        }
        newTurret = Instantiate(fakeTurret);
        placeTurret = true;
    }
}
