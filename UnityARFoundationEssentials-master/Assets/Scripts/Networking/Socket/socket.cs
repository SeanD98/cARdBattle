using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class socket : MonoBehaviour
{
    public SocketIOComponent Socket;

    private void Start()
    {
        StartCoroutine(ConnectToServer());
        Socket.On("USER_CONNECTED", OnUserConnected);
        Socket.On("PLAY", OnUserConnected);
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);

        Socket.Emit("USER_CONNECT");

        yield return new WaitForSeconds(1f);

        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = "User 1";
        Socket.Emit("PLAY", new JSONObject(data));
    }

    private void OnUserConnected( SocketIOEvent evt)
    {
        Debug.Log("msg: " + evt.data);
    }

    private void OnUserPlay(SocketIOEvent evt)
    {
        Debug.Log("msg: " + evt);
    }
}
