using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public LivesUI lUI;
    public GameObject livesText;

    private void Start()
    {
        lUI = livesText.GetComponent<LivesUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            Destroy(other.gameObject);
            lUI.SetLives(1);

        }
    }
}
