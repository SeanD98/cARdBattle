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
using CI.HttpClient.Core;

namespace CI.HttpClient.Core
{
    public class updateCardAPI : MonoBehaviour
    {
        // Start is called before the first frame update
        public void upgradeCard()
        {
            HttpClient client = new HttpClient();

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

            client.Post(new System.Uri("http://167.99.91.53/api/updateCard"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, (r) =>
            {
                var resultString = r.ReadAsString();

                if (resultString.Contains("true"))
                { //success code
                    Debug.Log("Card Upgraded!" + resultString);
                    Analytics.CustomEvent("Card Upgraded");
                }
                else
                { //fail code
                    Debug.Log("Upgrade Failed" + resultString);
                }
            }, (u) =>
            {

            });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
