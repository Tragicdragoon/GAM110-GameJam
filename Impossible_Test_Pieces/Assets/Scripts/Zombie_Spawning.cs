using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawning : MonoBehaviour
{
    Transform spawnPoint;
    public Transform target;
    public GameObject zombiePrefab;
    public List<GameObject> zombies;
    float spawnTimer;

    void Start()
    {
        spawnPoint = this.transform;
        spawnTimer = 2.0f;
    }
    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            GameObject newZombie = Instantiate(zombiePrefab, spawnPoint);
            zombies.Add(newZombie);
            newZombie.GetComponent<Zombie_Control>().spawnPoint = this.gameObject;
            spawnTimer = 3.0f;
        }
    }
}
