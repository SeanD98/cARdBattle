using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System.Web;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

namespace CI.HttpClient.Core
{
    public class signupScript : MonoBehaviour
    {
        [SerializeField]
        public InputField Username;

        [SerializeField]
        public InputField Password;

        [SerializeField]
        public InputField confirmedPassword;

        string enteredUsername;
        string enteredPassword;
        string enteredConfirmedPassword;

        public void signUp()
        {
            HttpClient client = new HttpClient();

            GameObject inputFieldUsernameObj = GameObject.Find("Username");
            string usernameInput = inputFieldUsernameObj.GetComponent<InputField>().text;

            GameObject inputFieldPasswordObj = GameObject.Find("Password");
            string passwordInput = inputFieldPasswordObj.GetComponent<InputField>().text;

            //GameObject inputFieldConfirmedPasswordObj = GameObject.Find("ConfirmedPassword");
            //string confirmedPasswordInput = inputFieldConfirmedPasswordObj.GetComponent<InputField>().text;

            enteredUsername = usernameInput;
            enteredPassword = passwordInput;
            //enteredConfirmedPassword = confirmedPasswordInput;

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "username", enteredUsername },
                { "password", enteredPassword }
            };

            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(data);

            //if (enteredPassword == enteredConfirmedPassword){
                client.Post(new System.Uri("http://167.99.91.53/api/createUser"), formUrlEncodedContent, HttpCompletionOption.AllResponseContent, (r) =>
                {
                    var resultString = r.ReadAsString();

                    if (resultString.Contains("true")){ //success code
                        Debug.Log("Signed Up Successfully" + resultString);
                        SceneManager.LoadScene("OnlineChooseFaction");
                        Analytics.CustomEvent("Account created");
                    } else { //fail code
                        Debug.Log("Sign Up Failed" + resultString);
                    }

                    print(r.ReadAsString());
                }, (u) => {

                });
           // } else {
                //Passwords did not match
        //    }
        }

        public void goToLogin()
        {
            SceneManager.LoadScene("LoginScreen");
        }

        public void goBackToMenu(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
