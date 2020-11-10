using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrencyStore : MonoBehaviour
{
    public Text CurrencyAmount;
    int CurrencyAmountInt;

    private void Start()
    {
        CurrencyAmountInt = MonsterBattlescript.coinsInt;
        CurrencyAmount.text = CurrencyAmountInt.ToString();
    }
}
