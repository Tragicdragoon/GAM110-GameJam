using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float lives = 20;
    public Text livesText;
    public GameObject spawner;

    private void Start()
    {
        livesText.text = "POPULATION: " + lives.ToString();
    }

    public void SetLives(int damage)
    {
        lives -= damage;
        livesText.text = "POPULATION: " + lives.ToString();

        if (lives <= 0)
        {
            int highScore = PlayerPrefs.GetInt("highscore");
            int newScore = spawner.GetComponent<Score>().score;
            PlayerPrefs.SetInt("score", newScore);
            
            if (newScore > highScore)
            {
                PlayerPrefs.SetInt("highscore", newScore);
            }

            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            spawner.GetComponent<Zombie_Spawning>().zombies.Remove(other.gameObject);
            Destroy(other.gameObject);
            SetLives(1);
        }
    }
}