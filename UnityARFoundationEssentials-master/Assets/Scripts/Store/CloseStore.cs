using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseStore : MonoBehaviour
{
    [SerializeField]
    public GameObject storeWindow;
    
    public void closeWindow()
    {
        storeWindow.SetActive(false);
    }
}
