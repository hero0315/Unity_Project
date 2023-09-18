using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashAttacker : MonoBehaviour
{
    [SerializeField]playerNearBy playernearBy;
    [SerializeField]SkillController skillController;
    [SerializeField]GameObject WaterSplash;
    int WaterSplashNum;
    void Update()
    {
        if(watersplashState.WaterSplashEnable&&watersplashState.WaterSplashcooldowning==false){
            GameObject Randomobj=playernearBy.GetComponent<playerNearBy>().getRandom(5.5f);
            if(Randomobj!=null){
                Attack(Randomobj);
            }
        }
        else if(watersplashState.WaterSplashEnable&&watersplashState.WaterSplashcooldowning==true){
            skillController.skillImagepool[WaterSplashNum].fillAmount+= (1/ watersplashState.WaterSplashcastspeed*Time.deltaTime);
            if(skillController.skillImagepool[WaterSplashNum].fillAmount>=1){
                watersplashState.WaterSplashcooldowning=false;
            }
        }
    }
    void Attack(GameObject Randomobj){
        setImage();
        Instantiate(WaterSplash,Randomobj.transform.position,Quaternion.Euler(0,0,0));
    }
    void setImage(){
        skillController.skillImagepool[WaterSplashNum].fillAmount=0;
        watersplashState.WaterSplashcooldowning=true;
    }
    public void setWaterSplashNum(int num){
        WaterSplashNum=num;
    }
}
