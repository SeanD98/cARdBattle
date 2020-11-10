using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using System.Net.Http;
using System.Web;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace CI.HttpClient.Core
{
    public class getCards : MonoBehaviour
    {
        public static getCards instance;
        public string selectedFaction;

        public object staticCard1Health;
        public object staticCard2Health;
        public object staticCard3Health;
        public object staticCard4Health;

        public object staticCard1Attack;
        public object staticCard2Attack;
        public object staticCard3Attack;
        public object staticCard4Attack;

        public object staticCard1Defence;
        public object staticCard2Defence;
        public object staticCard3Defence;
        public object staticCard4Defence;


        [SerializeField]
        public Text Title;

        [SerializeField]
        public Text Cards1Text1;
        [SerializeField]
        public Text Cards1Text2;
        [SerializeField]
        public Text Cards1Text3;
        [SerializeField]
        public Text Cards1Text4;

        [SerializeField]
        public Text Cards2Text1;
        [SerializeField]
        public Text Cards2Text2;
        [SerializeField]
        public Text Cards2Text3;
        [SerializeField]
        public Text Cards2Text4;

        [SerializeField]
        public Text Cards3Text1;
        [SerializeField]
        public Text Cards3Text2;
        [SerializeField]
        public Text Cards3Text3;
        [SerializeField]
        public Text Cards3Text4;

        [SerializeField]
        public Text Cards4Text1;
        [SerializeField]
        public Text Cards4Text2;
        [SerializeField]
        public Text Cards4Text3;
        [SerializeField]
        public Text Cards4Text4;

        [SerializeField]
        public UnityEngine.UI.Button Health;
        [SerializeField]
        public UnityEngine.UI.Button Attack;
        [SerializeField]
        public UnityEngine.UI.Button Defence;

        [SerializeField]
        public GameObject Panel;

        [SerializeField]
        public UnityEngine.UI.Button Ghost;
        [SerializeField]
        public UnityEngine.UI.Button Monster;
        [SerializeField]
        public UnityEngine.UI.Button Demon;

        [SerializeField]
        public RawImage Card1GhostBackground;
        [SerializeField]
        public RawImage Card2GhostBackground;
        [SerializeField]
        public RawImage Card3GhostBackground;
        [SerializeField]
        public RawImage Card4GhostBackground;

        [SerializeField]
        public RawImage Card1MonsterBackground;
        [SerializeField]
        public RawImage Card2MonsterBackground;
        [SerializeField]
        public RawImage Card3MonsterBackground;
        [SerializeField]
        public RawImage Card4MonsterBackground;

        [SerializeField]
        public RawImage Card1DemonBackground;
        [SerializeField]
        public RawImage Card2DemonBackground;
        [SerializeField]
        public RawImage Card3DemonBackground;
        [SerializeField]
        public RawImage Card4DemonBackground;

        public int Faction;

        public void Start()
        {
            instance = this;
        }

        public void retrieveCards()
        {
            HttpClient client = new HttpClient();
            string response;

            if (Faction.Equals(2))
            {
                 client.Get(new System.Uri("http://167.99.91.53/api/getCards/2"), HttpCompletionOption.AllResponseContent, (r) =>
                            {
                                response = r.ReadAsString();

                                JSONObject json = new JSONObject(response);
                                var stringJSON = (string)json.ToString();
                                var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringJSON);

                                object cards;
                                values.TryGetValue("Cards", out cards);
                                var test = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(cards.ToString());
                                Title.text = "Current Cards: Ghost";

                                //set Faction Card BG
                                Card1GhostBackground.enabled = true;
                                Card2GhostBackground.enabled = true;
                                Card3GhostBackground.enabled = true;
                                Card4GhostBackground.enabled = true;

                                //Disable others
                                Card1MonsterBackground.enabled = false;
                                Card2MonsterBackground.enabled = false;
                                Card3MonsterBackground.enabled = false;
                                Card4MonsterBackground.enabled = false;

                                Card1DemonBackground.enabled = false;
                                Card2DemonBackground.enabled = false;
                                Card3DemonBackground.enabled = false;
                                Card4DemonBackground.enabled = false;

                                //This is the method to get elements of the cards. 
                                var Card1 = test[0];
                                object Card1Name;
                                object Card1Health;
                                object Card1AttackPower;
                                object Card1Defence;
                                Card1.TryGetValue("Name", out Card1Name);
                                Card1.TryGetValue("Health", out Card1Health);
                                instance.staticCard1Health = Card1Health.ToString();
                                Card1.TryGetValue("Attack Power", out Card1AttackPower);
                                instance.staticCard1Health = Card1AttackPower.ToString();
                                Card1.TryGetValue("Defence", out Card1Defence);
                                instance.staticCard1Defence = Card1Defence.ToString();
                                Cards1Text1.text = "Name: " + (Card1Name.ToString());
                                Cards1Text2.text = "Health: " + (Card1Health.ToString());
                                Cards1Text3.text = "Attack Power: " + (Card1AttackPower.ToString());
                                Cards1Text4.text = "Defence: " + (Card1Defence.ToString());

                                var Card2 = test[1];
                                object Card2Name;
                                object Card2Health;
                                object Card2AttackPower;
                                object Card2Defence;
                                Card2.TryGetValue("Name", out Card2Name);
                                Card2.TryGetValue("Health", out Card2Health);
                                instance.staticCard2Health = Card2Health.ToString();
                                Card2.TryGetValue("Attack Power", out Card2AttackPower);
                                instance.staticCard2Attack = Card2AttackPower.ToString();
                                Card2.TryGetValue("Defence", out Card2Defence);
                                instance.staticCard2Defence = Card2Defence.ToString();
                                Cards2Text1.text = "Name: " + (Card2Name.ToString());
                                Cards2Text2.text = "Health: " + (Card2Health.ToString());
                                Cards2Text3.text = "Attack Power: " + (Card2AttackPower.ToString());
                                Cards2Text4.text = "Defence: " + (Card2Defence.ToString());

                                var Card3 = test[2];
                                object Card3Name;
                                object Card3Health;
                                object Card3AttackPower;
                                object Card3Defence;
                                Card3.TryGetValue("Name", out Card3Name);
                                Card3.TryGetValue("Health", out Card3Health);
                                instance.staticCard3Health = Card3Health.ToString();
                                Card3.TryGetValue("Attack Power", out Card3AttackPower);
                                instance.staticCard3Attack = Card3AttackPower.ToString();
                                Card3.TryGetValue("Defence", out Card3Defence);
                                instance.staticCard3Defence = Card3Defence.ToString();
                                Cards3Text1.text = "Name: " + (Card3Name.ToString());
                                Cards3Text2.text = "Health: " + (Card3Health.ToString());
                                Cards3Text3.text = "Attack Power: " + (Card3AttackPower.ToString());
                                Cards3Text4.text = "Defence " + (Card3Defence.ToString());

                                var Card4 = test[3];
                                object Card4Name;
                                object Card4Health;
                                object Card4AttackPower;
                                object Card4Defence;
                                Card4.TryGetValue("Name", out Card4Name);
                                Card4.TryGetValue("Health", out Card4Health);
                                instance.staticCard4Health = Card4Health.ToString();
                                Card4.TryGetValue("Attack Power", out Card4AttackPower);
                                instance.staticCard4Attack = Card4AttackPower.ToString();
                                Card4.TryGetValue("Defence", out Card4Defence);
                                instance.staticCard4Defence = Card4Defence.ToString();
                                Cards4Text1.text = "Name: " + (Card4Name.ToString());
                                Cards4Text2.text = "Health: " + (Card4Health.ToString());
                                Cards4Text3.text = "Attack Power: " + (Card4AttackPower.ToString());
                                Cards4Text4.text = "Defence: " + (Card4Defence.ToString());
                            });
            }

            else if (Faction.Equals(1))
            {
                client.Get(new System.Uri("http://167.99.91.53/api/getCards/1"), HttpCompletionOption.AllResponseContent, (r) =>
                {
                    response = r.ReadAsString();

                    JSONObject json = new JSONObject(response);
                    var stringJSON = (string)json.ToString();
                    var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringJSON);

                    object cards;
                    values.TryGetValue("Cards", out cards);
                    var test = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(cards.ToString());
                    Title.text = "Current Cards: Monster";
                    
                    //set Faction Card BG
                    Card1MonsterBackground.enabled = true;
                    Card2MonsterBackground.enabled = true;
                    Card3MonsterBackground.enabled = true;
                    Card4MonsterBackground.enabled = true;

                    //Disable others
                    Card1GhostBackground.enabled = false;
                    Card2GhostBackground.enabled = false;
                    Card3GhostBackground.enabled = false;
                    Card4GhostBackground.enabled = false;

                    Card1DemonBackground.enabled = false;
                    Card2DemonBackground.enabled = false;
                    Card3DemonBackground.enabled = false;
                    Card4DemonBackground.enabled = false;

                    //This is the method to get elements of the cards. 
                    var Card1 = test[0];
                    object Card1Name;
                    object Card1Health;
                    object Card1AttackPower;
                    object Card1Defence;
                    Card1.TryGetValue("Name", out Card1Name);
                    Card1.TryGetValue("Health", out Card1Health);
                    instance.staticCard1Health = Card1Health.ToString();
                    Card1.TryGetValue("Attack Power", out Card1AttackPower);
                    instance.staticCard1Attack = Card1AttackPower.ToString();
                    Card1.TryGetValue("Defence", out Card1Defence);
                    instance.staticCard1Defence = Card1Defence.ToString();
                    Cards1Text1.text = "Name: " + (Card1Name.ToString());
                    Cards1Text2.text = "Health: " + (Card1Health.ToString());
                    Cards1Text3.text = "Attack Power: " + (Card1AttackPower.ToString());
                    Cards1Text4.text = "Defence: " + (Card1Defence.ToString());

                    var Card2 = test[1];
                    object Card2Name;
                    object Card2Health;
                    object Card2AttackPower;
                    object Card2Defence;
                    Card2.TryGetValue("Name", out Card2Name);
                    Card2.TryGetValue("Health", out Card2Health);
                    instance.staticCard2Health = Card2Health.ToString();
                    Card2.TryGetValue("Attack Power", out Card2AttackPower);
                    instance.staticCard2Attack = Card2AttackPower.ToString();
                    Card2.TryGetValue("Defence", out Card2Defence);
                    instance.staticCard2Defence = Card2Defence.ToString();
                    Cards2Text1.text = "Name: " + (Card2Name.ToString());
                    Cards2Text2.text = "Health: " + (Card2Health.ToString());
                    Cards2Text3.text = "Attack Power: " + (Card2AttackPower.ToString());
                    Cards2Text4.text = "Defence: " + (Card2Defence.ToString());

                    var Card3 = test[2];
                    object Card3Name;
                    object Card3Health;
                    object Card3AttackPower;
                    object Card3Defence;
                    Card3.TryGetValue("Name", out Card3Name);
                    Card3.TryGetValue("Health", out Card3Health);
                    instance.staticCard3Health = Card3Health.ToString();
                    Card3.TryGetValue("Attack Power", out Card3AttackPower);
                    instance.staticCard3Attack = Card3AttackPower.ToString();
                    Card3.TryGetValue("Defence", out Card3Defence);
                    instance.staticCard3Defence = Card3Defence.ToString();
                    Cards3Text1.text = "Name: " + (Card3Name.ToString());
                    Cards3Text2.text = "Health: " + (Card3Health.ToString());
                    Cards3Text3.text = "Attack Power: " + (Card3AttackPower.ToString());
                    Cards3Text4.text = "Defence " + (Card3Defence.ToString());

                    var Card4 = test[3];
                    object Card4Name;
                    object Card4Health;
                    object Card4AttackPower;
                    object Card4Defence;
                    Card4.TryGetValue("Name", out Card4Name);
                    Card4.TryGetValue("Health", out Card4Health);
                    instance.staticCard4Health = Card4Health.ToString();
                    Card4.TryGetValue("Attack Power", out Card4AttackPower);
                    instance.staticCard4Attack = Card4AttackPower.ToString();
                    Card4.TryGetValue("Defence", out Card4Defence);
                    instance.staticCard4Defence = Card4Defence.ToString();
                    Cards4Text1.text = "Name: " + (Card4Name.ToString());
                    Cards4Text2.text = "Health: " + (Card4Health.ToString());
                    Cards4Text3.text = "Attack Power: " + (Card4AttackPower.ToString());
                    Cards4Text4.text = "Defence: " + (Card4Defence.ToString());
                });
            }

            else if (Faction.Equals(3))
            {
                client.Get(new System.Uri("http://167.99.91.53/api/getCards/3"), HttpCompletionOption.AllResponseContent, (r) =>
                {
                    response = r.ReadAsString();

                    JSONObject json = new JSONObject(response);
                    var stringJSON = (string)json.ToString();
                    var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringJSON);

                    object cards;
                    values.TryGetValue("Cards", out cards);
                    var test = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(cards.ToString());
                    Title.text = "Current Cards: Demon";

                     //set Faction Card BG
                    Card1DemonBackground.enabled = true;
                    Card2DemonBackground.enabled = true;
                    Card3DemonBackground.enabled = true;
                    Card4DemonBackground.enabled = true;                    
                    
                    //Disable others
                    Card1MonsterBackground.enabled = false;
                    Card2MonsterBackground.enabled = false;
                    Card3MonsterBackground.enabled = false;
                    Card4MonsterBackground.enabled = false;

                    Card1GhostBackground.enabled = false;
                    Card2GhostBackground.enabled = false;
                    Card3GhostBackground.enabled = false;
                    Card4GhostBackground.enabled = false;


                    //This is the method to get elements of the cards. 
                    var Card1 = test[0];
                    object Card1Name;
                    object Card1Health;
                    object Card1AttackPower;
                    object Card1Defence;
                    Card1.TryGetValue("Name", out Card1Name);
                    Card1.TryGetValue("Health", out Card1Health);
                    instance.staticCard1Health = Card1Health.ToString();
                    Card1.TryGetValue("Attack Power", out Card1AttackPower);
                    instance.staticCard1Attack = Card1AttackPower.ToString();
                    Card1.TryGetValue("Defence", out Card1Defence);
                    instance.staticCard1Defence = Card1Defence.ToString();
                    Cards1Text1.text = "Name: " + (Card1Name.ToString());
                    Cards1Text2.text = "Health: " + (Card1Health.ToString());
                    Cards1Text3.text = "Attack Power: " + (Card1AttackPower.ToString());
                    Cards1Text4.text = "Defence: " + (Card1Defence.ToString());

                    var Card2 = test[1];
                    object Card2Name;
                    object Card2Health;
                    object Card2AttackPower;
                    object Card2Defence;
                    Card2.TryGetValue("Name", out Card2Name);
                    Card2.TryGetValue("Health", out Card2Health);
                    instance.staticCard2Health = Card2Health.ToString();
                    Card2.TryGetValue("Attack Power", out Card2AttackPower);
                    instance.staticCard2Attack = Card2AttackPower.ToString();
                    Card2.TryGetValue("Defence", out Card2Defence);
                    instance.staticCard2Defence = Card2Defence.ToString();
                    Cards2Text1.text = "Name: " + (Card2Name.ToString());
                    Cards2Text2.text = "Health: " + (Card2Health.ToString());
                    Cards2Text3.text = "Attack Power: " + (Card2AttackPower.ToString());
                    Cards2Text4.text = "Defence: " + (Card2Defence.ToString());

                    var Card3 = test[2];
                    object Card3Name;
                    object Card3Health;
                    object Card3AttackPower;
                    object Card3Defence;
                    Card3.TryGetValue("Name", out Card3Name);
                    Card3.TryGetValue("Health", out Card3Health);
                    instance.staticCard3Health = Card3Health.ToString();
                    Card3.TryGetValue("Attack Power", out Card3AttackPower);
                    instance.staticCard3Attack = Card3AttackPower.ToString();
                    Card3.TryGetValue("Defence", out Card3Defence);
                    instance.staticCard3Defence = Card3Defence.ToString();
                    Cards3Text1.text = "Name: " + (Card3Name.ToString());
                    Cards3Text2.text = "Health: " + (Card3Health.ToString());
                    Cards3Text3.text = "Attack Power: " + (Card3AttackPower.ToString());
                    Cards3Text4.text = "Defence " + (Card3Defence.ToString());

                    var Card4 = test[3];
                    object Card4Name;
                    object Card4Health;
                    object Card4AttackPower;
                    object Card4Defence;
                    Card4.TryGetValue("Name", out Card4Name);
                    Card4.TryGetValue("Health", out Card4Health);
                    instance.staticCard4Health = Card4Health.ToString();
                    Card4.TryGetValue("Attack Power", out Card4AttackPower);
                    instance.staticCard4Attack = Card4AttackPower.ToString();
                    Card4.TryGetValue("Defence", out Card4Defence);
                    instance.staticCard4Defence = Card4Defence.ToString();
                    Cards4Text1.text = "Name: " + (Card4Name.ToString());
                    Cards4Text2.text = "Health: " + (Card4Health.ToString());
                    Cards4Text3.text = "Attack Power: " + (Card4AttackPower.ToString());
                    Cards4Text4.text = "Defence: " + (Card4Defence.ToString());
                });
            }
    
        }

        public void GhostSelected()
        {
            Faction = 2;
            instance.Faction = 2;
            Destroy(Panel, 1);
            selectedFaction = "Ghost";
            retrieveCards();
        }

        public void MonsterSelected()
        {
            Faction = 1;
            instance.Faction = 1;
            Destroy(Panel, 1);
            selectedFaction = "Monster";
            retrieveCards();
        }

        public void DemonSelected()
        {
            Faction = 3;
            instance.Faction = 3;
            Destroy(Panel, 1);
            selectedFaction = "Demon";
            retrieveCards();
        }
    }
}
