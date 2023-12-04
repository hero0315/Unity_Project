using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UpgradeSceneController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI totalkilltext;
    [SerializeField]private TextMeshProUGUI totaltimetext;
    [SerializeField]private TextMeshProUGUI totalcointext;
    [SerializeField]private TextMeshProUGUI cointext;
    [SerializeField]private GameObject UpgradePanel;
    [SerializeField]private GameObject RecordPanel;
    [SerializeField]private GameObject StagePanel;
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
    void Awake(){
        PassData passdata=GameObject.Find("PassData").GetComponent<PassData>();
        totalkilltext.text="Total killed : "+passdata.totalkill;
        totaltimetext.text="Total Survival Time : "+passdata.totaltime;
        totalcointext.text="Total coin get : "+passdata.totalcoin;
        cointext.text=""+coin;
    }
    void Update()
    {
        
    }
}
