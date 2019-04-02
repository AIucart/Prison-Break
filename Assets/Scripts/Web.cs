using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class Web : MonoBehaviour
{

    public string test;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                JSONNode data = JSON.Parse(webRequest.downloadHandler.text);
                test = data["release_date"].Value;
                int testValue;
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                if(int.TryParse(test, out testValue))
                {
                    testValue = int.Parse(test);
                    GameManager.instance.desc = test;
                }


            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://ghibliapi.herokuapp.com/films/cd3d059c-09f4-4ff3-8d63-bc765a5184fa"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(test);


        }
    }
}
