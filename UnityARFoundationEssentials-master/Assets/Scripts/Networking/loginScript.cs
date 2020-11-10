using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System.Web;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

namespace CI.HttpClient.Core {
    public class loginScript : MonoBehaviour
    {
        private static string res = "";

        [SerializeField]
        public InputField usernameField;

        [SerializeField]
        public InputField passwordField;

        string enteredUsername;
        string enteredPassword;

        public void login()
        {
            HttpClient client = new HttpClient();

            GameObject inputFieldUsernameObj = GameObject.Find("Username");
            string usernameInput = inputFieldUsernameObj.GetComponent<InputField>().text;

            GameObject inputFieldPasswordObj = GameObject.Find("Password");
            string passwordInput = inputFieldPasswordObj.GetComponent<InputField>().text;

            enteredUsername = usernameInput;
            enteredPassword = passwordInput;

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "username", enteredUsername },
                { "password", enteredPassword }
            };

            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

            client.Post(new System.Uri("http://167.99.91.53/api/login"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, (r) =>
            {      
                var resultString = r.ReadAsString();

                if (resultString.Contains("true")){
                    Debug.Log("Signed in" + resultString);
                    SceneManager.LoadScene("OnlineChooseFaction");
                    Analytics.CustomEvent("User signed in");
                } else if (resultString.Contains("Account not found")){
                    Debug.Log("Sign in failed, account not found" + resultString);
                    Analytics.CustomEvent("User sign in failed, account does not exist");
                } else if (resultString.Contains("Password is incorrect")) {
                    Debug.Log("Sign in failed, incorrect password");
                    Analytics.CustomEvent("User sign in failed, incorrect password");
                } else {
                    Debug.Log("Sign in failed");
                    Analytics.CustomEvent("User sign in failed, Unknown reason");
                }
                
                print(r.ReadAsString());
            }, (u) => {
                //During data upload
            });
        }

        public void goToSignUp()
        {
            Analytics.CustomEvent("User signing up");
            SceneManager.LoadScene("SignUpScreen");
        }
    }
}
