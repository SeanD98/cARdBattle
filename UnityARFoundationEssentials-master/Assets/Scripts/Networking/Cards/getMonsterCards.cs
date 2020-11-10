using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using System.Net.Http;
using System.Web;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

namespace CI.HttpClient.Core {
    public class getMonsterCards : MonoBehaviour
    {
        public void retreiveCards()
        {
            HttpClient client = new HttpClient();
            string response;
            client.Get(new System.Uri("http://167.99.91.53/api/getCards/1"), HttpCompletionOption.AllResponseContent, (r) => 
            {
                response = r.ReadAsString();
                print(response);
            });
        }
    }
}