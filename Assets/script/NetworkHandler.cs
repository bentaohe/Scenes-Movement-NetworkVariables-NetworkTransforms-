using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkHandler : NetworkBehaviour
{
    void Start()
    {
        NetworkManager.Singleton.OnClientStarted += OnClientStarted;
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
    }

    private bool hasPrinted = false;
    private void PrintMe()
    {
        if (hasPrinted)
        {
            return;
        }
        Debug.Log("Wassup");
        hasPrinted = true;
        if (IsServer)
        {
            Debug.Log("Server!");
        }
        if (IsHost)
        {
            Debug.Log("Host!");
        }
        if (IsClient)
        {
            Debug.Log("Client!");
        }
        if (!IsServer && !IsClient)
        {
            Debug.Log("False!");
            hasPrinted = false;
        }
    }

    private void OnClientStarted()
    {

    }

    private void OnServerStarted()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += ServerOnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += ServerOnClientDisconnected;
    }

    private void ServerSetup()
    {

    }

    private void ServerOnClientConnected(ulong clientId)
    {
        // This method is called when a client connects to the server.
        Debug.Log($"Client {clientId} connected to the server.");
    }

    private void ServerOnClientDisconnected(ulong clientId)
    {
        // This method is called when a client disconnects from the server.
        Debug.Log($"Client {clientId} disconnected from the server.");
    }
}