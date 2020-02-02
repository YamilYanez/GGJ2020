using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        Vector3 newForce = new Vector3((float)Math.Sin(t * 2) * 4 * Time.deltaTime, 0, 0);
        transform.Translate(newForce);
    }
}
