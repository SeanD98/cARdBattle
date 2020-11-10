using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System.Web;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;
using Newtonsoft.Json;

namespace CI.HttpClient.Core {
    public class upgradeCard : MonoBehaviour
    {
        [SerializeField]
        public Text coinAmount;

        [SerializeField]
        public GameObject errorPanel;

        public int Coins;

        public void UpgradeCard()
        {
            HttpClient client = new HttpClient();
        }

        public void HealthClicked()
        {
            HttpClient client = new HttpClient();
            int FactionSelectedS = getCards.instance.Faction;
            string CoinAmount = coinAmount.text.ToString();
            Coins = int.Parse(CoinAmount);

            if (coinAmount.text.Equals("1000C")){

                if (FactionSelectedS.Equals(1))
                {
                    int CardID = 1;

                    string sOldHealth = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldHealth = int.Parse(sOldHealth);
                    int Health = (ParsedOldHealth + 50);

                    string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldAttack = int.Parse(sOldAttackPower);
                    int AttackPower = (ParsedOldAttack);

                    string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                    int ParsedOldDefence = int.Parse(sOldDefence);
                    int Defence = (ParsedOldDefence);

                    Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                    FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                    client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                   {
                       var resultString = r.ReadAsString();

                       if (resultString.Contains("true"))
                       { //success code
                        Debug.Log("Card Upgraded!" + resultString);
                           Coins = 0;
                           coinAmount.text = "0 C";
                           Analytics.CustomEvent("Card Upgraded");
                       }
                       else
                       { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                       }

                       print(r.ReadAsString());
                   }, (u) =>
                   {

                   });
                }
                else if (FactionSelectedS.Equals(2))
                {
                    int CardID = 5;

                    string sOldHealth = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldHealth = int.Parse(sOldHealth);
                    int Health = (ParsedOldHealth + 50);

                    string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldAttack = int.Parse(sOldAttackPower);
                    int AttackPower = (ParsedOldAttack);

                    string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                    int ParsedOldDefence = int.Parse(sOldDefence);
                    int Defence = (ParsedOldDefence);

                    Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                    FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                    client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                    {
                        var resultString = r.ReadAsString();

                        if (resultString.Contains("true"))
                        { //success code
                            Coins = 0;
                            coinAmount.text = "0 C";
                            Debug.Log("Card Upgraded!" + resultString);
                            Analytics.CustomEvent("Card Upgraded");
                        }
                        else
                        { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                        }

                        print(r.ReadAsString());
                    }, (u) =>
                    {

                    });
                }
                else if (FactionSelectedS.Equals(3))
                {
                    int CardID = 9;

                    string sOldHealth = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldHealth = int.Parse(sOldHealth);
                    int Health = (ParsedOldHealth + 50);

                    string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                    int ParsedOldAttack = int.Parse(sOldAttackPower);
                    int AttackPower = (ParsedOldAttack);

                    string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                    int ParsedOldDefence = int.Parse(sOldDefence);
                    int Defence = (ParsedOldDefence);

                    Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                    FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                    client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                    {
                        var resultString = r.ReadAsString();

                        if (resultString.Contains("true"))
                        { //success code
                            Coins = 0;
                            coinAmount.text = "0 C";
                            Debug.Log("Card Upgraded!" + resultString);
                            Analytics.CustomEvent("Card Upgraded");
                        }
                        else
                        { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                        }

                        print(r.ReadAsString());
                    }, (u) =>
                    {

                    });
                }
            } else
            {
                //show errorPanel 
                errorPanel.SetActive(true);
            }
        }

        public void DefenceClicked()
        {
            HttpClient client = new HttpClient();
            int FactionSelectedS = getCards.instance.Faction;

            if (FactionSelectedS.Equals(1))
            {
                int CardID = 1;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence + 50);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
            else if (FactionSelectedS.Equals(2))
            {
                int CardID = 5;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence + 50);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
            else if (getCards.instance.selectedFaction.Equals("Demon"))
            {
                int CardID = 9;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence + 50);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
        }

        public void AttackClicked()
        {
            HttpClient client = new HttpClient();
            int FactionSelectedS = getCards.instance.Faction;

            if (FactionSelectedS.Equals(1))
            {
                int CardID = 1;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack + 50);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
            else if (FactionSelectedS.Equals(2))
            {
                int CardID = 5;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack + 50);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
            else if (FactionSelectedS.Equals(3))
            {
                int CardID = 9;

                string sOldHealth = getCards.instance.staticCard1Health.ToString();
                int ParsedOldHealth = int.Parse(sOldHealth);
                int Health = (ParsedOldHealth);

                string sOldAttackPower = getCards.instance.staticCard1Health.ToString();
                int ParsedOldAttack = int.Parse(sOldAttackPower);
                int AttackPower = (ParsedOldAttack + 50);

                string sOldDefence = getCards.instance.staticCard1Defence.ToString();
                int ParsedOldDefence = int.Parse(sOldDefence);
                int Defence = (ParsedOldDefence);

                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"CardID", CardID.ToString()},
                    {"Health", Health.ToString()},
                    {"Defence",  Defence.ToString()},
                    {"AttackPower", AttackPower.ToString()}
                };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

                client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, responseCallback: (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true"))
                    { //success code
                        Coins = 0;
                        coinAmount.text = "0 C";
                        Debug.Log("Card Upgraded!" + resultString);
                        Analytics.CustomEvent("Card Upgraded");
                    }
                    else
                    { //fail code
                        Debug.Log("Upgrade Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
            }
        }

    }
}
