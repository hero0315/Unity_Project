using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Net;
using System.IO;
public class MainMenuUI : MonoBehaviour
{
    private string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
    private string databaseSecret = "";
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI passwordtext; 
    public void startgame(){
        SceneManager.LoadScene("fightingScenes");
    }
    public class Playerinfo{
        public string name;
        public string password;
    }
    private bool existResponse(string url,string playerData){
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
                if(data=="null"){
                    return false;
                }
                else{
                    Debug.Log("帳號已存在");
                    return true;
                }
            }
            else{
                Debug.Log("網路錯誤");
                return true;
            }
        }
    }
    private void putResponse(string url,string playerData){
        if (!string.IsNullOrEmpty(databaseSecret))
        {
            url += "?auth=" + databaseSecret;
        }
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "PUT";
        request.ContentType = "application/json";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(playerData);
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
    }
    private Playerinfo getResponse(string url){
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
                if(data=="null"){
                    return null;
                }
                else{
                    Playerinfo playerinfo = JsonUtility.FromJson<Playerinfo>(data);
                    return playerinfo;
                }
            }
            else
            {
                return null;
            }
        }
    }
    private string Deletelast(string s){
        string text = string.Empty;
        for(int n=0;n<s.Length-1;n++)
        {
           if(s[n].ToString()!=""&&s[n].ToString()!=" "){
                text+=s[n];
           }
        }
        return text;
    }
    public void login(){
        string name=Deletelast(nametext.text);
        string pas=Deletelast(passwordtext.text);
        string url = databaseURL + "Users/"+name+".json";
        Playerinfo playerinfo =getResponse(url);
        if(playerinfo!=null){
            if(playerinfo.password==pas){
                Debug.Log("登入成功");
            }
            else{
                Debug.Log("帳號或密碼錯誤");
            }
        }
        else{
                Debug.Log("帳號不存在");
            }
    }
    public void register(){
        string name=Deletelast(nametext.text);
        string pas=Deletelast(passwordtext.text);
        string url = databaseURL + "Users/"+name+".json";
        bool ok=true;
        if(name.Length>10||name.Length<4){
            Debug.Log("名稱必須為英文且介於4~10個字");
            ok=false;
        }
        if(pas.Length>10||pas.Length<4){
            Debug.Log("密碼必須為英文且介於4~10個字");
            ok=false;
        }
        if(ok==true){
            string jsonData = "{\"name\": \""+name+"\",\"password\": "+pas+"}";
            if(!existResponse(url,jsonData)){
                putResponse(url,jsonData);
                Debug.Log("成功註冊");
            }
        }
    }
    
}
