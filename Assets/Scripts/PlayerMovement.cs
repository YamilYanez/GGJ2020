using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // public Controls controls;
    Vector2 movementInput;

    private void OnMove(InputValue val) {
        movementInput = val.Get<Vector2>();
    }

    void Update(){
        Vector3 newForce = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(newForce);
    }
}
