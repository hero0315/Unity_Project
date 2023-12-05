using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Net;
using System.IO;
using System.Linq;
using System;
public class MainMenuUI : MonoBehaviour
{
    private string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
    private string databaseSecret = "";
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI passwordtext; 
    public TextMeshProUGUI warningtext; 
    public GameObject PlayButton;
    public GameObject RegisterButton;
    public GameObject LoginButton;
    [SerializeField]public GameObject passData;
    public void startgame(){
        SceneManager.LoadScene("UpgradeScenes");
    }
    public class Playerinfo{
        public string name;
        public string password;
    }
    [System.Serializable]
    public class Record{
        public int totalmoney;
        public int totalkillnumber;
        public float totaltime;
        public int totalDiedTimes;
        public int totalmoneyspend;
        public int totallevelTimes;
        public int totalitemget;
        public UpgradeRecord upgradeRecord;
        public String getUgRecord(){
            return JsonUtility.ToJson(upgradeRecord);
        }
    }
    [System.Serializable]
    public class UpgradeRecord{
            public int HealthUpgrade;
            public float CoolDownRecover;
        }
    private bool existResponse(string url,int type){
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
                    return false;
                }
                else{
                    if(type==1){
                        warningtext.text="Account Name Exist";
                        Debug.Log("帳號已存在");
                    }
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
        text=s.Substring(0,s.Length-1);
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
                PlayButton.SetActive(true);
                RegisterButton.SetActive(false);
                LoginButton.SetActive(false);
                passData.GetComponent<PassData>().setName(name);
                getplayerData();
            }
            else{
                warningtext.text="Wrong Password Or Account Name";
                Debug.Log("帳號或密碼錯誤");
            }
        }
        else{
                warningtext.text="Account Name doesn't";
                Debug.Log("帳號不存在");
        }
    }
    public void register(){
        string name=Deletelast(nametext.text);
        string pas=Deletelast(passwordtext.text);
        string url = databaseURL + "Users/"+name+".json";
        bool ok=true;
        if(name.Length>10 || name.Length<4 && name.All(Char.IsDigit) && name.All(Char.IsLetter)){
            warningtext.text="Account Name must be English or Number and between 4~10 characters";
            Debug.Log("名稱必須為英文且介於4~10個字");
            ok=false;
        }
        else if(pas.Length>10 || pas.Length<4 && pas.All(Char.IsDigit) && pas.All(Char.IsLetter)){
            warningtext.text="Password must be English or Number and between 4~10 characters";
            Debug.Log("密碼必須為英文且介於4~10個字");
            ok=false;
        }
        if(ok==true){
            string jsonData = "{\"name\": \""+name+"\",\"password\": \""+pas+"\"}";
            if(!existResponse(url,1)){
                putResponse(url,jsonData);
                warningtext.text="Registration Success";
                Debug.Log("成功註冊");
            }
        }
    }
    public void getplayerData(){
        string name=Deletelast(nametext.text);
        string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
        string url = databaseURL + "Record/"+name+"/"+"TotalRecord"+".json";
        if(existResponse(url,0)){
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
                    Record record=JsonUtility.FromJson<Record>(data);
                    passData.GetComponent<PassData>().setcoin(record.totalmoney);
                    passData.GetComponent<PassData>().setkill(record.totalkillnumber);
                    passData.GetComponent<PassData>().settime(record.totaltime);
                    passData.GetComponent<PassData>().setdied(record.totalDiedTimes);
                    passData.GetComponent<PassData>().setlevelup(record.totallevelTimes);
                    passData.GetComponent<PassData>().setitem(record.totalitemget);
                    passData.GetComponent<PassData>().setmoneyspend(record.totalmoneyspend);
                    passData.GetComponent<PassData>().setHealthUpgrade(record.upgradeRecord.HealthUpgrade);
                    passData.GetComponent<PassData>().setCoolDownRecover(record.upgradeRecord.CoolDownRecover);
                }
                else{
                    Debug.Log("totalreord下載失敗");
                }
            }
        }
        else{
            string jsonData ="{\"totaltime\": \"" + 0 + "\",\"totalmoney\": " + 0 + ",\"totalkillnumber\": " + 0+",\"totalDiedTimes\": " + 0+
        ",\"totallevelTimes\": " +0+",\"totalmoneyspend\": " +0+",\"totalitemget\": " +0+",\"upgradeRecord\": {\"HealthUpgrade\": "+0+",\"CoolDownRecover\": "+0+"}"+"}";
            Debug.Log(jsonData);
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
        }
    }
    
}
