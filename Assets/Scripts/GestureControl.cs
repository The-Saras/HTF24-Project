using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GestureControl : MonoBehaviour
{
    // Replace "YOUR_API_URL" with the actual URL of the API you want to request
    private string apiUrl = "http://127.0.0.1:8000/result";
    public string s;

    public GameObject bullet;

    public GameObject bullet1;
    public Transform firePoint;
    public movement move;

    [System.Serializable]
    public class MyData
    {
        
        public int result;
    }
    void Start()
    {
        StartCoroutine(MakeContinuousGetRequests());
    }

    IEnumerator MakeContinuousGetRequests()
    {
        while (true)  // Infinite loop for continuous requests
        {
            // Create a UnityWebRequest object for the GET request
            using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
            {
                // Send the request and wait for a response
                yield return webRequest.SendWebRequest();

                // Check for errors
                if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                    webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError("Error: " + webRequest.error);
                }
                else
                {
                    
                    byte[] rawData = webRequest.downloadHandler.data;

                    
                    string downloadedText = System.Text.Encoding.UTF8.GetString(rawData);

                    MyData myData = JsonUtility.FromJson<MyData>(downloadedText);
                    int resultValue = myData.result;
                    
                    if(resultValue==1){
                         Instantiate(bullet1,firePoint.position , transform.rotation);
                    }
                    else if(resultValue==2){
                        Instantiate(bullet,firePoint.position , transform.rotation);
                    }
                    
                }
            }

            // Add a delay between requests (e.g., 5 seconds)
            yield return new WaitForSeconds(0.7f);
        }
    }

    
    
}


