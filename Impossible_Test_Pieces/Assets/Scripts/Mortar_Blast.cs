using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Blast : MonoBehaviour
{
    Transform blast;
    public float radius;
    float scale;

    void Start()
    {
        blast = transform;
        scale = 0.1f;
    }

    void Update()
    {
        if (radius >= blast.localScale.y)
        {
            scale += 0.1f;
            blast.localScale = new Vector3(scale, scale, scale);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
