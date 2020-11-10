using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPuchasePanel : MonoBehaviour
{
    [SerializeField]
    public Text purchaseAmount;

    [SerializeField]
    public Button purchaseButton;

    [SerializeField]
    public RawImage coinIconImage1000C;

    [SerializeField]
    public RawImage coinIconImage2800C;

    [SerializeField]
    public RawImage coinIconImage5000C;

    [SerializeField]
    public RawImage coinIconImage13500C;

    [SerializeField]
    public GameObject PurchasePanel;

    void Start()
    {
        PurchasePanel.SetActive(false);    
    }

    public void ShowPanel()
    {
        PurchasePanel.SetActive(true);
    }

    public void purchase1000()
    {
        PurchasePanel.SetActive(true);

        purchaseAmount.text = "Would you like to purchase 1000 C for £3.99?";
        coinIconImage1000C.IsActive().Equals(true);
        coinIconImage2800C.IsActive().Equals(false);
        coinIconImage5000C.IsActive().Equals(false);
        coinIconImage13500C.IsActive().Equals(false);
    }

    public void purchase2800()
    {
        PurchasePanel.SetActive(true);

        purchaseAmount.text = "Would you like to purchase 2800 C for £9.99?";
        coinIconImage1000C.IsActive().Equals(false);
        coinIconImage2800C.IsActive().Equals(true);
        coinIconImage5000C.IsActive().Equals(false);
        coinIconImage13500C.IsActive().Equals(false);

    }

    public void purchase5000()
    {
        PurchasePanel.SetActive(true);

        purchaseAmount.text = "Would you like to purchase 5000 C for £14.99?";
        coinIconImage1000C.IsActive().Equals(false);
        coinIconImage2800C.IsActive().Equals(false);
        coinIconImage5000C.IsActive().Equals(true);
        coinIconImage13500C.IsActive().Equals(false);

    }

    public void purchase13500()
    {
        PurchasePanel.SetActive(true);

        purchaseAmount.text = "Would you like to purchase 13,500 C for £39.99?";
        coinIconImage1000C.IsActive().Equals(false);
        coinIconImage2800C.IsActive().Equals(false);
        coinIconImage5000C.IsActive().Equals(false);
        coinIconImage13500C.IsActive().Equals(true);
    }

    public void PurchaseCoins()
    {
        //Complete purchase
    }

}
