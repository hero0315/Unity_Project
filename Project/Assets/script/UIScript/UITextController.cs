using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;
using System.IO;
using UnityEngine.Events;
using System;

public class UITextController : MonoBehaviour
{
    private float maxHealth;
    [SerializeField]private TextMeshProUGUI expText;
    [SerializeField]private Slider expSlider;
    [SerializeField]private TextMeshProUGUI levelText;
    [SerializeField]private TextMeshProUGUI lifeText;
    [SerializeField]private Slider lifeSlider;
    [SerializeField]private GameObject LevelSelect;
    [SerializeField]private GameObject DiedSelect;
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private TextMeshProUGUI timer;
    public static UnityEvent expEvent;
    public static UnityEvent hpEvent;
    private int[]level_need_exp;
    void Start(){    
        playerState.playername = GameObject.Find("PassData").GetComponent<PassData>().playerName;
        Debug.Log(playerState.playername);
        if(playerState.isrestart==false){
            PlayerData data = SaveSystem.LoadPlayerdata();
            playerState.level=data.level;
            playerState.exp=data.exp;
        }
        if (expEvent == null)
            expEvent = new UnityEvent();
        expEvent.AddListener(getexp);
        if (hpEvent == null)
            hpEvent = new UnityEvent();
        hpEvent.AddListener(getdamaged);
        level_need_exp = new int[] { 50,50,50,50,50,750,800,900,1200,1700,2650,4000,6000,8750,12350,17000,22850,30050,38850,49400,61850,76500,93550,113150,135650,161250,190200,222750,259250,299950,345100,395100,450200,510700,577050,649500,728400,814150,907150,1007750,1116350,1233350,1359150,1494200,1638900,1793700,1959100,2135500,2323400,2523250,2735600,2960850,3199650,3452400,3719650,4001950,4299850,4613950,4944750,5292850,5658850,6043300,6446850,6870100,7313650,7778200,8264350,8772700,9304000,9858900,10438050,11042200,11671950,12328100,13011350,13722450,14462050,15231000,16030000,16859850,17721300,18615150,19542200,20503250,21499150,22530700,23598700,24704000,25847500,27030050,28252550,29515800,30820800,32168350,33559400,34994900,36475800,38002950,39577350,41200000,42871800,44593750,46366850,48192150};
        //level_need_exp = new int[] { 50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,750,800,900,1200,1700,2650,4000,6000,8750,12350,17000,22850,30050,38850,49400,61850,76500,93550,113150,135650,161250,190200,222750,259250,299950,345100,395100,450200,510700,577050,649500,728400,814150,907150,1007750,1116350,1233350,1359150,1494200,1638900,1793700,1959100,2135500,2323400,2523250,2735600,2960850,3199650,3452400,3719650,4001950,4299850,4613950,4944750,5292850,5658850,6043300,6446850,6870100,7313650,7778200,8264350,8772700,9304000,9858900,10438050,11042200,11671950,12328100,13011350,13722450,14462050,15231000,16030000,16859850,17721300,18615150,19542200,20503250,21499150,22530700,23598700,24704000,25847500,27030050,28252550,29515800,30820800,32168350,33559400,34994900,36475800,38002950,39577350,41200000,42871800,44593750,46366850,48192150};
        maxHealth=playerState.playerHealth;
        expText.text="0 / "+level_need_exp[playerState.level-1];
        expSlider.maxValue=level_need_exp[playerState.level-1];
        levelText.text="LV : "+playerState.level;
        lifeText.text=maxHealth+" / "+maxHealth;
        lifeSlider.maxValue=maxHealth;
        expSlider.value=playerState.exp;
        lifeSlider.value=playerState.playerHealth;
        expText.text=playerState.exp+" / "+level_need_exp[playerState.level-1];
    }
    public void setMaxHealth(float newMaxlife){
        maxHealth=newMaxlife;
        lifeText.text=playerState.playerHealth+" / "+maxHealth;
        lifeSlider.maxValue=maxHealth;
        lifeSlider.value=playerState.playerHealth;
    }
    private void levelUp(){
        playerState.exp-=level_need_exp[playerState.level-1];
        playerState.level+=1;
        expText.text=playerState.exp+" / "+level_need_exp[playerState.level-1];
        expSlider.value=playerState.exp;
        expSlider.maxValue=level_need_exp[playerState.level-1];
        levelText.text="LV : "+playerState.level;
        LevelSelect.GetComponent<LevelSelectController>().levelup();
        eventController.pauseEvent.Invoke();
    }
    private void getexp(){
        while(playerState.exp>=level_need_exp[playerState.level-1]){
            levelUp();
        }
        expText.text=playerState.exp+" / "+level_need_exp[playerState.level-1];
        expSlider.value=playerState.exp;
    }
    private void getdamaged(){
        lifeSlider.value=playerState.playerHealth;
        lifeText.text=playerState.playerHealth+" / "+maxHealth;
        if(playerState.playerHealth<=0){
            lifeText.text="0"+" / "+maxHealth;
            died();
        }
    }
    private void died(){
        playerState.canEsc=false;
        eventController.pauseEvent.Invoke();
        DiedSelect.SetActive(true);
        coinText.text=""+playerState.coin;
        updateData();
        updateTotalData();
    }
    private void updateData(){
        string upgradeData="";
        int i=1;
        foreach(string SkillUpgradeRecord in LevelSelectController.selectRecord.Keys){
            upgradeData+="\""+SkillUpgradeRecord+"\": "+LevelSelectController.selectRecord[SkillUpgradeRecord];
            i++;
            if(LevelSelectController.selectRecord.Count>=i){
                upgradeData+=",";
            }
        }
        string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
        string url = databaseURL + "Record/"+playerState.playername+"/"+DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")+".json";
        string playerData = "{\"time\": \"" + timer.text + "\",\"money\": " + playerState.coin + ",\"killnumber\": " + playerState.killnumber + ",\"Level\": " + playerState.level + 
        ",\"SkillUpgradeRecord\": {"+upgradeData+"}}";
        Debug.Log(playerData);
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
    private void updateTotalData(){
        string databaseURL = "https://game-ab172-default-rtdb.firebaseio.com/";
        string url = databaseURL + "Record/"+playerState.playername+"/"+"TotalRecord"+".json";
        PassData passdata=GameObject.Find("PassData").GetComponent<PassData>();
        passdata.totalcoin+=playerState.coin;
        passdata.totalkill+=playerState.killnumber;
        passdata.totaltime+=Timer.time;
        string jsonData ="{\"totaltime\": \"" + passdata.totaltime + "\",\"totalmoney\": " + passdata.totalcoin + ",\"totalkillnumber\": " + passdata.totalkill+",\"totalDiedTimes\": " + (passdata.totalDiedTimes+1)+
        ",\"totallevelTimes\": " +(passdata.totallevelTimes+playerState.level-1)+",\"totalmoneyspend\": " +passdata.totalmoneyspend+",\"totalitemget\": " +(passdata.totalitemGet+playerState.itemget)+",\"upgradeRecord\": {\"HealthUpgrade\": "+passdata.HealthUpgrade+",\"CoolDownRecover\": "+passdata.CooldownRecover+"}"+"}";
        HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url);
        request2.Method = "PUT";
        request2.ContentType = "application/json";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request2.ContentLength = data.Length;
        using (Stream requestStream = request2.GetRequestStream())
        {
            requestStream.Write(data, 0, data.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
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

