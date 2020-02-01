using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class DestroyPot : MonoBehaviour
{
    public Rigidbody rb;
    public SphereCollider sphereCollider;
    public float detectionRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = detectionRadius;
    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log(collider);
    }
}
