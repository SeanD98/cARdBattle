using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketBattleScript : MonoBehaviour
{
    private SocketIOComponent socket;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageDealt()
    {
        //Socket damage 
        //get damage num from battlescript 
        //Create multiple of these classes for each battleScene
        //push damage num to server
    }
}
