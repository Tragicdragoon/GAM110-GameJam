using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    public GameObject[] enemies;
    Transform target;
    public GameObject bullet;
    public float radius;
    Transform turret;
    float fireRate;
    void Start()
    {
        target = null;
        turret = transform;
        fireRate = 0;
    }

    void Update()
    {
        if (target != null)
        {
            if (Physics.Linecast(turret.position, target.position) && Vector3.Distance(turret.position, target.transform.position) < radius)
            {
                turret.LookAt(target.position);
                fireRate -= Time.deltaTime;

                if (fireRate <= 0)
                {
                    Instantiate(bullet, turret.position, turret.rotation);
                    fireRate = 0.5f;
                }
                
            }

            else
            {
                target = null;
            }
        }

        if (target == null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (Physics.Linecast(turret.position, enemy.transform.position) && Vector3.Distance(turret.position, enemy.transform.position) < radius)
                {
                    
                    target = enemy.transform;
                }
            }
        }
    }
}
