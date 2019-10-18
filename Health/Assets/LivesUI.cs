using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    private float lives = 20;

    public TextMeshProUGUI livesText;
    void Start()
    {
        lives = 20;
    }

    public void SetLives(int damage)
    {
        lives -= damage;
        livesText.text = lives.ToString() + " Lives";
    }

}
