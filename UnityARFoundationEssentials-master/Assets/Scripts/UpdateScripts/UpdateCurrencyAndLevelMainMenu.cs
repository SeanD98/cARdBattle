using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrencyAndLevelMainMenu : MonoBehaviour
{
    public Text Currency;
    public Text Level;
    public Text XP;
    public Text RemainingXP;

    int CurrencyInt;
    int LevelInt;
    int XPInt;
    int RemainingXPInt;

    void Start()
    {
        CurrencyInt = MonsterBattlescript.coinsInt;
        LevelInt = MonsterBattlescript.accountLevelInt;
        XPInt = MonsterBattlescript.xp;
        RemainingXPInt = MonsterBattlescript.remainingXPInt;

        Currency.text = CurrencyInt.ToString();
        Level.text = LevelInt.ToString();
        XP.text = XPInt.ToString();
        RemainingXP.text = RemainingXPInt.ToString();
    }
}
