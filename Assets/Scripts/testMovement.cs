using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    float t = 0;
    public bool doRotation = false;
    public bool doMovement = true;
    public Vector3 axis = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(doMovement){
            Vector3 newForce = new Vector3((float)Math.Sin(t * 2) * 4 * Time.deltaTime, 0, 0);
            transform.Translate(newForce);
        }

        if(doRotation) {
            transform.Rotate(axis * 45 * Time.deltaTime);
        }
    }
}
