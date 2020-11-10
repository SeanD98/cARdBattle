using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WasAPurchaseMade : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Analytics.CustomEvent("Purchase Made");
    }
}
