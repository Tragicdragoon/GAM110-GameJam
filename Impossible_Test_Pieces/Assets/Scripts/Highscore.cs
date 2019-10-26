using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    public Text scoreTXT;
    public Text highscoreTXT;

    void Start()
    {
        scoreTXT.text = PlayerPrefs.GetInt("score").ToString();
        highscoreTXT.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
