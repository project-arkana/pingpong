using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour {

    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            if (GUILayout.Button("Start Server"))
            {
                Network.InitializeServer(32, 25000, false);
            }
            if (GUILayout.Button("Connect Locally"))
            {
                Network.Connect("127.0.0.1", 25000);
            }
        }
        else
        {
            if (GUILayout.Button("Disconnect"))
            {
                Network.Disconnect();
            }
        }           
    }

    // Called on Server when a Client connects
    void OnPlayerConnected()
    {
        networkView.RPC("Ping", RPCMode.All);
    }

    [RPC]
    void Ping()
    {
        Debug.LogError(Time.frameCount + " :: PING!");
        if (Network.isServer)
        {
            networkView.RPC("Pong", RPCMode.All);
        }
    }

    [RPC]
    void Pong()
    {
        Debug.LogError(Time.frameCount + " :: PONG!");
    }
}
