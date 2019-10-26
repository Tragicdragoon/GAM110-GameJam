using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    List<GameObject> enemies;
    public Transform target;
    public GameObject spawner;
    public GameObject bullet;
    public float radius;
    Transform turret;
    public float fireRate;
    float tillFire;
    public bool fixRotation;

    void Start()
    {
        target = null;
        turret = transform;
        tillFire = fireRate;
    }

    void Update()
    {
        enemies = spawner.GetComponent<Zombie_Spawning>().zombies;
        tillFire -= Time.deltaTime;

        if (target != null)
        {
            if (Physics.Linecast(turret.position, target.position) && Vector3.Distance(turret.position, target.transform.position) < radius)
            {
                turret.LookAt(new Vector3(target.position.x, 0.5f, target.position.z));
                if(fixRotation == true)
                {
                    turret.Rotate(new Vector3(0, 270, 0));
                }

                if (tillFire <= 0)
                {
                    Instantiate(bullet, turret);
                    tillFire = fireRate;
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
                if (enemy != null && Physics.Linecast(turret.position, enemy.transform.position) && Vector3.Distance(turret.position, enemy.transform.position) < radius)
                {
                    
                    target = enemy.transform;
                }
            }
        }
    }
}
