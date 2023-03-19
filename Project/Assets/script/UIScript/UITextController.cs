using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    private float currentExp;
    private float currentHealth;
    private float maxHealth;
    [SerializeField]private Text expText;
    [SerializeField]private Slider expSlider;
    [SerializeField]private Text lifeText;
    [SerializeField]private Slider lifeSlider;
    private int[]levelup;
    void Start(){    
        levelup = new int[] { 750,800,900,1200,1700,2650,4000,6000,8750,12350,17000,22850,30050,38850,49400,61850,76500,93550,113150,135650,161250,190200,222750,259250,299950,345100,395100,450200,510700,577050,649500,728400,814150,907150,1007750,1116350,1233350,1359150,1494200,1638900,1793700,1959100,2135500,2323400,2523250,2735600,2960850,3199650,3452400,3719650,4001950,4299850,4613950,4944750,5292850,5658850,6043300,6446850,6870100,7313650,7778200,8264350,8772700,9304000,9858900,10438050,11042200,11671950,12328100,13011350,13722450,14462050,15231000,16030000,16859850,17721300,18615150,19542200,20503250,21499150,22530700,23598700,24704000,25847500,27030050,28252550,29515800,30820800,32168350,33559400,34994900,36475800,38002950,39577350,41200000,42871800,44593750,46366850,48192150};
        maxHealth=playerState.playerHealth;
        expText.text="0 / "+levelup[playerState.level-1];
        expSlider.maxValue=levelup[playerState.level-1];
        lifeText.text=maxHealth+" / "+maxHealth;
        lifeSlider.maxValue=maxHealth;
        currentExp=playerState.exp;
        expSlider.value=currentExp;
        currentHealth=playerState.playerHealth;
        lifeSlider.value=currentHealth;
    }
    void Update(){
        if(playerState.exp!=currentExp){
            gotexp();
        }
        if(playerState.playerHealth!=currentHealth){
            getdamaged();
        }
    }
    public void setMaxHealth(float newMaxlife){
        maxHealth=newMaxlife;
        lifeText.text=playerState.playerHealth+" / "+maxHealth;
        lifeSlider.maxValue=maxHealth;
        lifeSlider.value=playerState.playerHealth;
    }
    private void levelUp(){
        playerState.exp-=levelup[playerState.level-1];
        playerState.level+=1;
        expText.text=playerState.exp+" / "+levelup[playerState.level-1];
        expSlider.value=playerState.exp;
        expSlider.maxValue=levelup[playerState.level-1];
    }
    private void gotexp(){
        while(playerState.exp>=levelup[playerState.level-1]){
            levelUp();
        }
        expText.text=playerState.exp+" / "+levelup[playerState.level-1];
        expSlider.value=playerState.exp;
        currentExp=playerState.exp;
    }
    private void getdamaged(){
        currentHealth=playerState.playerHealth;
        lifeSlider.value=currentHealth;
        lifeText.text=playerState.playerHealth+" / "+maxHealth;
        if(playerState.playerHealth<=0){
            Debug.Log("You Lose!!");
        }
    }
}
