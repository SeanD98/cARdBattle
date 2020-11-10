using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battleScript : MonoBehaviour
{
    [SerializeField]
    public string scenename;

    public static battleScript instance;

    public SimpleHealthBar EnemyHealthBar;
    public SimpleHealthBar PlayerHealthBar;

    public SimpleHealthBar EnemyDefenceBar;
    public SimpleHealthBar PlayerDefenceBar;

    public Text accountLevel;
    public static int accountLevelInt = 1;

    public Text XP;
    public static int xp;
    public Text RemainingXP;
    public static int remainingXPInt;

    public Text Coins;
    public static int coinsInt = 1000;

    float YourHealth = 1000.0f;
    float EnemyHealth = 1000.0f;

    float YourDefence = 1000.0f;
    float EnemyDefence = 1000.0f;

    float maxValue = 1000.0f;
    float currentValue = 1000.0f;

    bool playerDead = false;
    bool enemyDead = false;

    public Text Outcome;

    bool clickReady = false;

    private void Start()
    {
        FloatingTextController.Initialise();
    }

    public void Attack()
    {
        EnemyDefence = Random.Range(1, 100);

        if (enemyDead != true && YourHealth > 0)
        {
            var DamageDelt = Random.Range(1, 100);
            if (DamageDelt == 100)
            {
                if (DamageDelt < EnemyDefence) {

                    FloatingTextController.CreateFloatingText(DamageDelt.ToString(), transform);



                    EnemyHealth = EnemyHealth - 90;
                    currentValue = EnemyHealth;
                    EnemyHealthBar.UpdateBar(currentValue, maxValue);

                    //crit hit max xp
                    xp = xp + 200;
                    XP.text = xp.ToString();

                    coinsInt = coinsInt + 50;
                    Coins.text = coinsInt.ToString();
                    checkOrSetLevel();

                } else
                {
                    //Attack blocked
                    EnemyDefence = EnemyDefence - DamageDelt;
                    currentValue = EnemyDefence;
                    EnemyDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfEnemyDead();
                if (EnemyHealth > 0)
                {
                    Invoke("getAttacked", Random.Range(1, 3));
                }
            }


            if (DamageDelt <= 30)
            {
                if (DamageDelt > EnemyDefence)
                {
                    EnemyHealth = EnemyHealth - Random.Range(1, 30);
                    currentValue = EnemyHealth;
                    EnemyHealthBar.UpdateBar(currentValue, maxValue);

                    //OK Hit
                    xp = xp + 75;
                    XP.text = xp.ToString();

                    coinsInt = coinsInt + 10;
                    Coins.text = coinsInt.ToString();
                    checkOrSetLevel();
                } else
                {
                    //attack blocked
                    EnemyDefence = EnemyDefence - DamageDelt;
                    currentValue = EnemyDefence;
                    EnemyDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfEnemyDead();

                if (EnemyHealth > 0)
                {
                    Invoke("getAttacked", 2);
                }
            }

            if (DamageDelt <= 50 && DamageDelt > 30)
            {
                if (DamageDelt > EnemyDefence)
                {
                    EnemyHealth = EnemyHealth - Random.Range(30, 50);
                    currentValue = EnemyHealth;
                    EnemyHealthBar.UpdateBar(currentValue, maxValue);

                    //Better hit
                    xp = xp + 100;
                    XP.text = xp.ToString();

                    coinsInt = coinsInt + 20;
                    Coins.text = coinsInt.ToString();
                    checkOrSetLevel();
                } else
                {
                    //attack blocked
                    EnemyDefence = EnemyDefence - DamageDelt;
                    currentValue = EnemyDefence;
                    EnemyDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfEnemyDead();

                if (EnemyHealth > 0)
                {
                    Invoke("getAttacked", Random.Range(1, 3));
                }
            }

            if (DamageDelt >= 80 && DamageDelt < 100)
            {
                if (DamageDelt > EnemyDefence)
                {
                    EnemyHealth = EnemyHealth - Random.Range(70, 85);
                    currentValue = EnemyHealth;
                    EnemyHealthBar.UpdateBar(currentValue, maxValue);

                    //Better hit
                    xp = xp + 150;
                    XP.text = xp.ToString();

                    coinsInt = coinsInt + 30;
                    Coins.text = coinsInt.ToString();
                    checkOrSetLevel();
                } else
                {
                    //attack blocked
                    EnemyDefence = EnemyDefence - DamageDelt;
                    currentValue = EnemyDefence;
                    EnemyDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfEnemyDead();

                if (EnemyHealth > 0)
                {
                    Invoke("getAttacked", Random.Range(1, 3));
                }
            }

            if (DamageDelt > 50 && DamageDelt < 80)
            {
                if (DamageDelt > EnemyDefence)
                {
                    EnemyHealth = EnemyHealth - Random.Range(50, 79);
                    currentValue = EnemyHealth;
                    EnemyHealthBar.UpdateBar(currentValue, maxValue);

                    xp = xp + 125;
                    XP.text = xp.ToString();

                    coinsInt = coinsInt + 40;
                    Coins.text = coinsInt.ToString();
                    checkOrSetLevel();
                } else
                {
                    //attack blocked
                    EnemyDefence = EnemyDefence - DamageDelt;
                    currentValue = EnemyDefence;
                    EnemyDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfEnemyDead();

                if (EnemyHealth > 0)
                {
                    Invoke("getAttacked", Random.Range(1, 3));
                }
            }
        }
    }

    void getAttacked()
    {
        YourDefence = Random.Range(1, 100);
        if (playerDead != true)
        {
            var DamageDelt = Random.Range(1, 100);
            if (DamageDelt == 100)
            {
                if (DamageDelt > YourDefence)
                {
                    YourHealth = YourHealth - 90;
                    currentValue = YourHealth;
                    PlayerHealthBar.UpdateBar(currentValue, maxValue);
                } else
                {
                    //attack blocked
                    YourDefence = YourDefence - DamageDelt;
                    currentValue = YourDefence;
                    PlayerDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfDead();
            }
            if (DamageDelt <= 30)
            {
                if (DamageDelt > YourDefence)
                {
                    YourHealth = YourHealth - Random.Range(1, 30);
                    currentValue = YourHealth;
                    PlayerHealthBar.UpdateBar(currentValue, maxValue);
                } else
                {
                    //attack blocked
                    YourDefence = YourDefence - DamageDelt;
                    currentValue = YourDefence;
                    PlayerDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfDead();
            }
            if (DamageDelt <= 50 && DamageDelt > 30)
            {
                if (DamageDelt > YourDefence)
                {
                    YourHealth = YourHealth - Random.Range(30, 50);
                    currentValue = YourHealth;
                    PlayerHealthBar.UpdateBar(currentValue, maxValue);
                } else
                {
                    //attack blocked
                    YourDefence = YourDefence - DamageDelt;
                    currentValue = YourDefence;
                    PlayerDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfDead();
            }
            if (DamageDelt >= 80 && DamageDelt < 100)
            {
                if (DamageDelt > YourDefence)
                {
                    YourHealth = YourHealth - Random.Range(70, 85);
                    currentValue = YourHealth;
                    PlayerHealthBar.UpdateBar(currentValue, maxValue);
                } else
                {
                    //attack blocked
                    YourDefence = YourDefence - DamageDelt;
                    currentValue = YourDefence;
                    PlayerDefenceBar.UpdateBar(currentValue, maxValue);
                }

                checkIfDead();
            }
            if (DamageDelt > 50 && DamageDelt < 80)
            {
                if (DamageDelt > YourDefence)
                {
                    YourHealth = YourHealth - Random.Range(50, 79);
                    currentValue = YourHealth;
                    PlayerHealthBar.UpdateBar(currentValue, maxValue);
                } else
                {
                    //attack blocked
                    YourDefence = YourDefence - DamageDelt;
                    currentValue = YourDefence;
                    PlayerDefenceBar.UpdateBar(currentValue, maxValue);
                }
                
                checkIfDead();
            }
        }
    }

    public void isClickReady()
    {
        clickReady = true;
    }

    void checkIfDead()
    {
        if (YourHealth <= 0)
        {
            playerDead = true;

            //You died 
            xp = xp - 50;

            //delete prefab
            Outcome.text = "Defeat";

            Invoke("SwapScene", 5);
        } 
    }

    void checkIfEnemyDead()
    {
        if (EnemyHealth <= 0)
        {
            enemyDead = true;

            //Enemy Killed
            xp = xp + 150;
            coinsInt = coinsInt + 1000;
            Coins.text = coinsInt.ToString();

            //delete prefab

            //Show outcome
            Outcome.text = "Victory!";

            Invoke("SwapScene", 5);
        } 
    }

    void checkOrSetLevel()
    {
        if (accountLevelInt == 1)
        {
            if (xp >= 1000)
            {
                //Rank Up from 1 to 2
                accountLevelInt = 2;
                accountLevel.text = "2";
                remainingXPInt = 2500;
                RemainingXP.text = "/2500XP";
            }
        }
        if (accountLevelInt == 2)
        {
            if (xp >= 2500)
            {
                //Rank up from 2 to 3
                accountLevelInt = 3;
                accountLevel.text = "3";
                RemainingXP.text = "/5000XP";
            }
        }
        if (accountLevelInt == 3)
        {
            if (xp >= 5000)
            {
                //Rank up from 3 to 4
                accountLevelInt = 4;
                accountLevel.text = "4";
                RemainingXP.text = "/9000XP";
            }
        }
        if (accountLevelInt == 4)
        {
            if (xp >= 9000)
            {
                //Rank up from 4 to 5
                accountLevelInt = 5;
                accountLevel.text = "5";
                RemainingXP.text = "/15,000XP";
            }
        }
        if (accountLevelInt == 5)
        {
            if (xp >= 15000)
            {
                //Rank up from 5 to 6
                accountLevelInt = 6;
                accountLevel.text = "6";
                RemainingXP.text = "/22,000XP";
            }
        }
        if (accountLevelInt == 6)
        {
            if (xp >= 22000)
            {
                //Rank up from 6 to 7
                accountLevelInt = 7;
                accountLevel.text = "7";
                RemainingXP.text = "/30,000XP";
            }
        }
        if (accountLevelInt == 7)
        {
            if (xp >= 30000)
            {
                //Rank up from 7 to 8
                accountLevelInt = 8;
                accountLevel.text = "MAX";
                RemainingXP.text = "";
            }
        }
    }

    void SwapScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
