using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;

    public TextMeshProUGUI scoreText;
    void Start()
    {
        score = 0;
    }

    public void SmallZombie()
    {
        score += 5;
        scoreText.text = score.ToString();
    }

    public void MediumZombie()
    {
        score += 15;
        scoreText.text = score.ToString();
    }

    public void LargeZombie()
    {
        score += 50;
        scoreText.text = score.ToString();
    }
}
