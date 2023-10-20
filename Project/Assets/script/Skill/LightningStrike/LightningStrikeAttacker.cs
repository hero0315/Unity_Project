using UnityEngine;
using System.Collections.Generic;
public class LightningStrikeAttacker : MonoBehaviour
{
    [SerializeField] SkillController skillController;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject LightningStrike;
    int LightningStrikeNum;
    List<GameObject> lightningStrikelist= new List<GameObject>();
    int totalnum=15;
    int num=0;
    public void setLightningStrikeNum(int num){
        LightningStrikeNum=num;
    }
    void Awake(){
        for(int i=0;i<totalnum;i++){
            lightningStrikelist.Add(Instantiate(LightningStrike));
            lightningStrikelist[i].SetActive(false);
        }
    }
    void Update()
    {
        if(LightningStrikeState.LightningStrikeEnable&&LightningStrikeState.LightningStrikecooldowning==false){
            GameObject Randomobj=nearbyDetect.GetComponent<playerNearBy>().getRandom(6f);
            if(Randomobj!=null){
                Attack(Randomobj);
            }
        }
        else if(LightningStrikeState.LightningStrikeEnable&&LightningStrikeState.LightningStrikecooldowning==true){
            skillController.skillImagepool[LightningStrikeNum].fillAmount+= (1/ LightningStrikeState.LightningStrikecastspeed*Time.deltaTime);
            if(skillController.skillImagepool[LightningStrikeNum].fillAmount>=1){
                LightningStrikeState.LightningStrikecooldowning=false;
            }
        }
    }
    void Attack(GameObject Randomobj){
        setImage();
        float damage=LightningStrikeState.LightningStrikedamage;
        eventController.damageEvent.Invoke(damage,this.transform.position);
        Randomobj.GetComponent<enemyController>().decreasehealth(damage);
        lightningStrikelist[num].transform.position=new Vector3(Randomobj.transform.position.x,Randomobj.transform.position.y-0.3f,0);
        lightningStrikelist[num].SetActive(true);
        lightningStrikelist[num].GetComponent<LightningStrike>().setfalse();
        num++;
        if(num>=totalnum){
            num=0;
        }
    }
    void setImage(){
        skillController.skillImagepool[LightningStrikeNum].fillAmount=0;
        LightningStrikeState.LightningStrikecooldowning=true;
    }
}
