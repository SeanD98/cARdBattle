using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class CharacterSocketScript : MonoBehaviour
{
    SocketIOComponent socket;
    JSONObject message;

    [SerializeField]
    public Button AttackButton;

    [SerializeField]
    public SimpleHealthBar playerHealthBar;

    [SerializeField]
    public SimpleHealthBar enemyHealthBar;

    [SerializeField]
    public GameObject theirTurn;

    [SerializeField]
    public GameObject yourTurn;

    public float DamageTaken;
    public float enemyHealth;
    public float enemyNewHealth;
    public float maxValue;
    float time;

    Animation anim;
    void Start()       
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        message = new JSONObject();
        socket.On("moveMade", OnMoveMade);

        //theirTurn.isActiveAndEnabled.Equals(false);
        //theirTurn.gameObject.SetActive(false);
        //yourTurn.isActiveAndEnabled.Equals(false);
        //yourTurn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        //socket.On("connection", OnConnect);
        socket.On("moveMade", OnMoveMade);
    }

    public void sendDamage()
    {

        //grey out the damage button
        AttackButton.interactable = false;
        message.AddField("damage",  DemonBattlescript.DamageDelt);
        socket.Emit("makeMove", message);
        message.Clear();
 
        //Show text, Their Turn
        //theirTurn.isActiveAndEnabled.Equals(true);
        //theirTurn.gameObject.SetActive(true);
        
        //decrement enemy bar
        anim = theirTurn.GetComponent<Animation>();
        anim.Play();

        // yourTurn.isActiveAndEnabled.Equals(false); 
        //yourTurn.gameObject.SetActive(false);

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

        //decrement your health bar by DamageTaken
        enemyHealthBar.UpdateBar(enemyNewHealth, maxValue);

        
        //Show text, Your Turn
        anim = theirTurn.GetComponent<Animation>();
        anim.Play();

        //Ungrey Button
        AttackButton.interactable = true;
    }

    public void DealDamageToOtherPlayer(float DamageDealt)
    {
        //Check shield amount
        //Decrement Enemy Health Bar
        //Check if player is dead 
        //If dead go back to main scene

    }

    public void TakeDamage(float DamageTaken)
    {
        //Check shield amount
        //Decrement Player Health Bar
        //Check if player is dead 
        //If dead go back to main scene

        //Try to reduce size of arObjectsToPlace OR add a counter for how many times battlescene has started
    }
}

