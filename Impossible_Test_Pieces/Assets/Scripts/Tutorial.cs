using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject aim;
    public GameObject recourse;
    public GameObject turrwt;
    int part;

    public void next()
    {
        part++;

        if (part == 1)
        {
            aim.SetActive(false);
            turrwt.SetActive(true);
        }

        if (part == 2)
        {
            turrwt.SetActive(false);
            recourse.SetActive(true);
        }

        if (part == 3)
        {
            SceneManager.LoadScene(0);
        }
    }
}
