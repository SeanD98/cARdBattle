using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    [SerializeField]
    public GameObject PlayerUnitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Since player is invisible, spawn something visable
        Instantiate(PlayerUnitPrefab);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
