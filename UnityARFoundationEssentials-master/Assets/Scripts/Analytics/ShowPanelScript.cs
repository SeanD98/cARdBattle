using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ShowPanelScript : MonoBehaviour
{
    public GameObject panel;
    
    // Start is called before the first frame update
    public void showPanel()
    {
        Analytics.CustomEvent("ProPurchase Considered");
        panel.gameObject.SetActive(true);
    }

    public void hidePanel()
    {
        if (panel.activeInHierarchy)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
