using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_Attack : MonoBehaviour
{
    Transform pulse;
    float radius;
    float scale;

    void Start()
    {
        pulse = transform;
        radius = GetComponentInParent<Turret_Control>().radius;
        scale = 0.1f;
    }

    void Update()
    {
        if ((radius * 1.5) >= pulse.localScale.y)
        {
            scale += 0.1f;
            pulse.localScale = new Vector3(scale, scale, scale);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
