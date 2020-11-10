using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class mySocketScript : MonoBehaviour
{
    public static mySocketScript instance;
    SocketIOComponent socket;

    [SerializeField]
    public Button AttackButton;

    [SerializeField]
    public GameObject YourTurn;

    [SerializeField]
    public GameObject theirTurn;

    [SerializeField]
    public SimpleHealthBar enemyHealthBar;

    public float DamageTaken;
    public float enemyHealth;
    public float enemyNewHealth;
    public float maxValue;

    // Start is called before the first frame update
    void Start()
    {

        socket = GetComponent<SocketIOComponent>();

        //Listener
        socket.On("connection", OnConnect);
        socket.On("moveMade", OnMoveMade);
    }

    // Update is called once per frame
    void Update()
    {
        socket.On("connection", OnConnect);
        socket.On("moveMade", OnMoveMade);
    }

    private void OnConnect(SocketIOEvent evt)
    {
        Debug.Log("Player is connected" + evt.data.GetField("id"));
    }

    public void OnMoveMade(SocketIOEvent evt)
    {
        Debug.Log("On Move Made Called!");
        AttackButton.interactable = true;
        enemyHealth = DemonBattlescript.instance.currentValue;
        maxValue = DemonBattlescript.instance.maxValue;
        Debug.Log("move made" + evt.data.GetField("msg"));
        //deal damage
        string StrDamageTaken = evt.data.GetField("msg").ToString();
        DamageTaken = float.Parse(StrDamageTaken);
        Debug.Log(DamageTaken);
        enemyNewHealth = enemyHealth - DamageTaken;

        //decrement enemy health bar by DamageTaken
        enemyHealthBar.UpdateBar(enemyNewHealth, maxValue);

        //Show text, Your Turn
        YourTurn.SetActive(true);
        theirTurn.SetActive(false);
        
        //Ungrey Button
        AttackButton.interactable = true;

        float time = 2;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(time);
            YourTurn.SetActive(false);
        }
    }
}
