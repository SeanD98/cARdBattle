using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletePurchase : MonoBehaviour
{
    [SerializeField]
    public Button continueButton;

    [SerializeField]
    public Text currencyAmount;

    [SerializeField]
    public GameObject purchasePanel;
    public void completePurchasefor1000C()
    {
        purchasePanel.SetActive(false);
        currencyAmount.text = "2000";
    }
    public void completePurchasefor2800C()
    {
        purchasePanel.SetActive(false);
        currencyAmount.text = "3800";
    }
    public void completePurchasefor5000C()
    {
        purchasePanel.SetActive(false);
        currencyAmount.text = "6000";
    }
    public void completePurchasefor13500C()
    {
        purchasePanel.SetActive(false);
        currencyAmount.text = "13500";
    }
}
