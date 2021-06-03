using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SyncVar(hook = nameof(OnHolaCountChanged))]
    int holaCount = 0;

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

        if(isLocalPlayer && Input.GetKeyDown(KeyCode.X)){
            Debug.Log("Sending Hola to server");
            Hola();
        }

        // if(isServer && transform.position.y > 50){
        //     TooHigh();
        // }
    }

    [Command]
    void Hola(){
        Debug.Log("Received Hola from client");
        holaCount++;
        ReplyHola();
    }

    [ClientRpc]
    void TooHigh(){
        Debug.Log("Too high");
    }

    [TargetRpc]
    void ReplyHola(){
        Debug.Log("Received Hola from server");
    }

    void OnHolaCountChanged(int oldCount, int newCount){
        Debug.Log($"We had {oldCount} holas, but now we have {newCount} holas");
    }
}
