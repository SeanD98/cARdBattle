using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class showStore : MonoBehaviour
{
    public GameObject Storepanel;
    public void showPanel()
    {
        Analytics.CustomEvent("Store Browsed");
        Storepanel.gameObject.SetActive(true);
    }
}
