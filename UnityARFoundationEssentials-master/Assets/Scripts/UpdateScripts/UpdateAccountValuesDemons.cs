using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAccountValuesDemons : MonoBehaviour
{
    public Text AccountLevel;
    int AccountLevelInt;

    public Text XPAmount;
    int XPAmountInt;
    public Text RemainingXP;
    int remainingXPInt;

    public Text CoinsAmount;
    int CoinsAmountInt;

    // Start is called before the first frame update
    void Start()
    {
        //Update Account level, XP and Coins from the battle. 
        XPAmountInt = DemonBattlescript.xp;
        XPAmount.text = XPAmountInt.ToString();
        remainingXPInt = DemonBattlescript.remainingXPInt;
        RemainingXP.text = remainingXPInt.ToString();

        CoinsAmountInt = DemonBattlescript.coinsInt;
        CoinsAmount.text = CoinsAmountInt.ToString();

        AccountLevelInt = DemonBattlescript.accountLevelInt;
        if (AccountLevelInt == 8)
        {
            AccountLevel.text = "MAX";
        }
        else
        {
            AccountLevel.text = AccountLevelInt.ToString();
        }
    }
}
