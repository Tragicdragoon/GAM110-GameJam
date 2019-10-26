using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void MediumZombie()
    {
        score += 50;
        scoreText.text = "SCORE: " + score.ToString();
    }
}