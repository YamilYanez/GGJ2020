using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera target_camera;

    void Update()
    {
        if(target_camera != null) {
            transform.LookAt(transform.position + target_camera.transform.rotation * Vector3.back, 
                target_camera.transform.rotation * Vector3.up);
        }
    }
}
