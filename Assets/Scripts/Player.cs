using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField]
    float moveSpeed;

    void HandleMovement(){
        if(isLocalPlayer){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position = transform.position + movement * Time.deltaTime * moveSpeed;
        }
    }

    private void Update() {
        HandleMovement();
    }
}
