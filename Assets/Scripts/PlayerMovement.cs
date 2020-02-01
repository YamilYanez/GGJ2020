﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controls;
    Vector2 movementInput;

    void Awake (){  
        controls = new Controls();
        controls.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

     void Update(){
        var rb = GetComponent<Rigidbody>();
        Vector3 newforce = new Vector3(movementInput.x,0,movementInput.y);
        Quaternion rotation = Quaternion.LookRotation(newforce,Vector3.up);
        transform.rotation= rotation;
        rb.AddForce(newforce * 60);
     }

    void OnEnable(){
        controls.Player.Enable();
    }
}