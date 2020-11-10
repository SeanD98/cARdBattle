using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class HidePanelOnStart : MonoBehaviour
{
    public GameObject ProPanel;
    public GameObject StorePanel;

    public void Start()
    {
        Analytics.CustomEvent("Pro Version Purchased");
        ProPanel.SetActive(false);
        StorePanel.SetActive(false);
    }
}
