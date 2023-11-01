using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;

public class connect : MonoBehaviour
{
    private string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
    private string databaseSecret = "";

    void Start()
    {
        //StartCoroutine(GetDataFromFirebase());
        StartCoroutine(WriteDataToFirebase());
    }
    private void Update()
    {
        //StartCoroutine(WriteDataToFirebase());
    }
        IEnumerator GetDataFromFirebase()
    {
        string url = databaseURL + "/Users/0000001.json";//取得玩家的資料路徑傳換成json檔
        if (!string.IsNullOrEmpty(databaseSecret))
        {
            url += "?auth=" + databaseSecret;
        }
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string data = reader.ReadToEnd();
                Debug.Log(data);
            }
            else
            {
                Debug.LogError("Error: " + response.StatusCode);
            }
        }
        yield return null;
    }
    IEnumerator WriteDataToFirebase()
    {
        string jsonData = "{\"name\": \"hero0315\",\"password\": 669}";
        string url = databaseURL + "/Users/hero0315.json";
        if (!string.IsNullOrEmpty(databaseSecret))
        {
            url += "?auth=" + databaseSecret;
        }
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "PUT";
        request.ContentType = "application/json";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.ContentLength = data.Length;
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(data, 0, data.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("Data written successfully.");
            }
            else
            {
                Debug.LogError("Error: " + response.StatusCode);
            }
        }
        yield return null;
    }
}