using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Linq;
using System;
public class UpgradeSceneController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI totalkilltext;
    [SerializeField]private TextMeshProUGUI totaltimetext;
    [SerializeField]private TextMeshProUGUI totalcointext;
    [SerializeField]private TextMeshProUGUI totalcoinspendtext;
    [SerializeField]private TextMeshProUGUI cointext;
    [SerializeField]private TextMeshProUGUI totalitemGettext;
    [SerializeField]private TextMeshProUGUI totalLevelUpTimestext;
    [SerializeField]private TextMeshProUGUI totalDiedTimestext;
    [SerializeField]private TextMeshProUGUI HealthUpgradetext;
    
    [SerializeField]private TextMeshProUGUI cooldownUpgradestext;
    
    [SerializeField]private GameObject UpgradePanel;
    [SerializeField]private GameObject RecordPanel;
    [SerializeField]private GameObject StagePanel;
    [SerializeField]private Button UpdateHealthbutton;
    [SerializeField]private Button CooldownRecoverbutton;
    int coin=0;
    public void Play()
    {
        SceneManager.LoadScene("fightingScenes");
    }
    public void openUpgrade(){
        UpgradePanel.SetActive(true);
        RecordPanel.SetActive(false);
        StagePanel.SetActive(false);
    }
    public void openRecord(){
        UpgradePanel.SetActive(false);
        RecordPanel.SetActive(true);
        StagePanel.SetActive(false);
    }
    public void openStage(){
        UpgradePanel.SetActive(false);
        RecordPanel.SetActive(false);
        StagePanel.SetActive(true);
    }
    public void UpgradeHealth(){
        PassData passdata=GameObject.Find("PassData").GetComponent<PassData>();
        if(coin>=10){
            coin-=10;
            cointext.text=""+coin;
            passdata.totalmoneyspend+=10;
            passdata.HealthUpgrade+=1;
            HealthUpgradetext.text=passdata.HealthUpgrade*10+" / 100";
            if(passdata.HealthUpgrade>=10){
                UpdateHealthbutton.interactable=false;
            }
        }
        string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
        string url = databaseURL + "Record/"+passdata.playerName+"/"+"TotalRecord"+".json";
        string jsonData ="{\"UpgradeRecord\": {\"HealthUpgrade\": "+passdata.HealthUpgrade+",\"CoolDownRecover\": "+ passdata.CooldownRecover+"}}";
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
    public void UpgradeCoolDown(){
        PassData passdata=GameObject.Find("PassData").GetComponent<PassData>();
        if(coin>=10){
            coin-=10;
            cointext.text=""+coin;
            passdata.totalmoneyspend+=10;
            passdata.CooldownRecover+=1;
            cooldownUpgradestext.text=passdata.CooldownRecover+"% / 5%";
            if(passdata.CooldownRecover>=5){
                CooldownRecoverbutton.interactable=false;
            }
        }
        string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
        string url = databaseURL + "Record/"+passdata.playerName+"/"+"TotalRecord"+".json";
        string jsonData ="{\"UpgradeRecord\": {\"HealthUpgrade\": "+passdata.HealthUpgrade+",\"CoolDownRecover\": "+ passdata.CooldownRecover+"}}";
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
    void Start(){
        PassData passdata=GameObject.Find("PassData").GetComponent<PassData>();
        totalkilltext.text="Total killed : "+passdata.totalkill;
        totaltimetext.text="Total Survival Time : "+passdata.totaltime;
        totalcointext.text="Total coin get : "+passdata.totalcoin;
        totalcoinspendtext.text="Total coin spend : "+passdata.totalmoneyspend;
        totalitemGettext.text="Total item get : "+passdata.totalitemGet;
        totalDiedTimestext.text="Total Died Times : "+passdata.totalDiedTimes;
        totalLevelUpTimestext.text="Total Levelup times get : "+passdata.totallevelTimes;
        HealthUpgradetext.text=passdata.HealthUpgrade+" / 10";
        if(passdata.HealthUpgrade>=10){
            UpdateHealthbutton.interactable=false;
        }
        cooldownUpgradestext.text=passdata.CooldownRecover+" / 5%";
        if(passdata.CooldownRecover>=5){
            CooldownRecoverbutton.interactable=false;
        }
        coin=passdata.totalcoin-passdata.totalmoneyspend;
        cointext.text=""+coin;
    }
}
