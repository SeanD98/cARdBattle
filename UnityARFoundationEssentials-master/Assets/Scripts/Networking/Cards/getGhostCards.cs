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

namespace CI.HttpClient.Core
{
    public class getGhostCards : MonoBehaviour
    {
        // Start is called before the first frame update
        public void retrieveCards()
        {
            HttpClient client = new HttpClient();
            string response;

            client.Get(new System.Uri("http://167.99.91.53/api/getCards/2"), HttpCompletionOption.AllResponseContent, (r) =>
            {
                response = r.ReadAsString();

                JSONObject json = new JSONObject(response);
                var stringJSON = (string)json.ToString();
                var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringJSON);

                object cards;
                values.TryGetValue("Cards", out cards);
                var test = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(cards.ToString());

                //This is the method to get elements of the cards. 
                //var test1 = test[1];
                //object test2;
                //test1.TryGetValue("Name", out test2);
            });

            
        }
    }
}

