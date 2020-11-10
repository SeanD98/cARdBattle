using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class CloseAD : MonoBehaviour
{
    public GameObject adPanel;
    // Start is called before the first frame update
    public void Closead()
    {
        Analytics.CustomEvent("Ad viewed, user closed");
        adPanel.SetActive(false);
    }
}
