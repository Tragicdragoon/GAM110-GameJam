using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawning : MonoBehaviour
{
    Transform spawnPoint;
    public GameObject zombiePrefab;
    public List<GameObject> zombies;
    public GameObject nodes;
    public float spawnTimer;
    public float spawnTime;
    float spawnBreak;
    public int spawnMaxCount;
    public int spawnMinCount;
    public int spawnCount;
    public int totalSpawn;

    void Start()
    {
        spawnMaxCount = 1;
        spawnMinCount = 1;
        spawnBreak = 0.3f;
        spawnTimer = 5.0f;
        spawnPoint = this.transform;

        spawnTime = Random.Range(spawnTimer * 0.75f, spawnTimer);        
        spawnCount = Random.Range(spawnMinCount, spawnMaxCount);
    }
    
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            spawnBreak -= Time.deltaTime;

            if (spawnBreak <= 0 && spawnCount >= 0)
            {
                GameObject newZombie = Instantiate(zombiePrefab, spawnPoint);
                zombies.Add(newZombie);
                newZombie.GetComponent<Zombie_Control>().spawnPoint = this.gameObject;
                newZombie.GetComponent<Zombie_Control>().nodes = nodes;

                totalSpawn += 1;
                spawnBreak = 0.1f;
                spawnCount -= 1;

                if (totalSpawn % 3 == 0 && spawnTimer >= 0.5f)
                {
                    spawnTimer -= 0.1f;
                }

                if (totalSpawn % 12 == 0 && spawnMaxCount <= 6)
                {
                    spawnMaxCount += 1;
                }

                if (totalSpawn % 20 == 0 && spawnMinCount <= 6)
                {
                    spawnMinCount += 1;
                }
            }
            
            if (spawnCount <= 0)
            {
                spawnTime = Random.Range(spawnTimer * 0.75f, spawnTimer);
                spawnCount = Random.Range(spawnMinCount, spawnMaxCount);
            }
        }
    }
}
