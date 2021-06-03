using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    /// <summary>Player Prefabs that can be spawned over the network need to be registered here.</summary>
    public GameObject[] playerPrefabs;

    List<int> playerIndeces = new List<int>();
    

    public override void OnStartServer()
    {
        // base.OnStartServer();
        Debug.Log("Server started");
    }

    public override void OnStopServer()
    {
        // base.OnStopServer();
        Debug.Log("Server stopped");
    }

    // public override void OnClientConnect(NetworkConnection conn)
    // {
    //     // base.OnClientConnect(conn);
    //     Debug.Log("Connected to server");
    // }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        // base.OnClientDisconnect(conn);
        Debug.Log("Disconnected from server");
    }

    //Called on client when connect
     public override void OnClientConnect(NetworkConnection conn) {       
         NetworkClient.AddPlayer();
         
     }
  
 // Server
     public override void OnServerAddPlayer(NetworkConnection conn) {
         //Select the prefab from the spawnable objects list
        //  var playerPrefab = playerPrefabs[curPlayer];       
  
         // Create player object with prefab
        //  var player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity) as GameObject;        
         
         // Add player object for connection
        //  NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
     }
}
