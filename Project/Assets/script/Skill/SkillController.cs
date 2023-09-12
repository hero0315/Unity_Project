using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillController : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private GameObject firepoint;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject fireball;
    [SerializeField]private GameObject lightningblast;
    [SerializeField]private Image skillImage_Q;
    [SerializeField]private Image skillImage_M1;
    [SerializeField]private Image skillImage_W;
    [SerializeField]private Image skillImage_E;
    [SerializeField]private Image skillImage_R;
    [SerializeField]private Sprite magicweaponSprite;
    [SerializeField]private Sprite fireballSprite;
    [SerializeField]private Sprite lightningblastSprite;
    [System.Serializable]
    public class skillpool{
        public GameObject skill;
        public string skillname;
        [System.NonSerialized]
        public float spellcastspeed;
        [System.NonSerialized]
        public bool iscooldowning=false;
        public void setskill(GameObject _skill,string _skillname,float _spellcastspeed){
            this.skill=_skill;
            this.spellcastspeed=_spellcastspeed;
            this.skillname=_skillname;
        }
        public void setcastspeed(){
            this.spellcastspeed=fireballState.Fireballcastspeed*playerState.playerCastspeed;
        }
    }
    [SerializeField]public List<skillpool> skillpools;
    void Start(){
        foreach(skillpool skill in skillpools){
            if(skill.skillname=="FireBall"){
                skill.spellcastspeed=fireballState.Fireballcastspeed*playerState.playerCastspeed;
            }
            else if(skill.skillname=="LightningBlast"){
                skill.spellcastspeed=lightningblastState.LightningBlastcastspeed*playerState.playerCastspeed;
            }
            else if(skill.skillname=="MagicWeapon"){
                skill.spellcastspeed=magicweaponState.MagicWeaponDuration;
            }
        }
    }
    void Update()
    {
        /*
            if(Input.GetButton("mouse1")&&skillpools[0]!=null&&skillpools[0].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[0]);
                skillpools[0].iscooldowning=true;
                skillImage_M1.fillAmount=0;
            }
            else{
                skillImage_M1.fillAmount+= (1/ skillpools[0].spellcastspeed*Time.deltaTime);
                if(skillImage_M1.fillAmount>=1){
                    skillpools[0].iscooldowning=false;
                }
            }
            */
                if(skillpools[0]!=null&&skillpools[0].iscooldowning==false){
                        Attack(skillpools[0],0);
                }
                else{
                    skillImage_M1.fillAmount+= (1/ skillpools[0].spellcastspeed*Time.deltaTime);
                    if(skillImage_M1.fillAmount>=1){
                        skillpools[0].iscooldowning=false;
                    }
                }
                if(skillpools[1]!=null&&skillpools[1].iscooldowning==false){
                        Attack(skillpools[1],1);
                }
                else{
                    skillImage_Q.fillAmount+= (1/ skillpools[1].spellcastspeed*Time.deltaTime);
                    if(skillImage_Q.fillAmount>=1){
                        skillpools[1].iscooldowning=false;
                    }
                }
                if(skillpools[2]!=null&&skillpools[2].iscooldowning==false){
                        Attack(skillpools[2],2);
                        
                }
                else{
                    skillImage_W.fillAmount+= (1/ skillpools[2].spellcastspeed*Time.deltaTime);
                    if(skillImage_W.fillAmount>=1){
                        skillpools[2].iscooldowning=false;
                    }
                }
                if(skillpools[3]!=null&&skillpools[3].iscooldowning==false){
                        Attack(skillpools[3],3);
                        
                }
                else{
                    skillImage_E.fillAmount+= (1/ skillpools[3].spellcastspeed*Time.deltaTime);
                    if(skillImage_E.fillAmount>=1){
                        skillpools[3].iscooldowning=false;
                    }
                }
                if(skillpools[4]!=null&&skillpools[4].iscooldowning==false){
                        Attack(skillpools[4],4);
                }
                else{
                    skillImage_R.fillAmount+= (1/ skillpools[4].spellcastspeed*Time.deltaTime);
                    if(skillImage_R.fillAmount>=1){
                        skillpools[4].iscooldowning=false;
                    }
                }
    }
    private void Attack(skillpool skill,int skillnum){
        GameObject Closest=nearbyDetect.GetComponent<playerNearBy>().getClosest();
        if(skill.skillname=="FireBall"){
            if(Closest!=null){
                useskill(skillnum);
                dir = Closest.transform.position-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                if(fireballState.FireballFireNum>1){
                    float angle=fireballState.FireballFireNum*10-fireballState.FireballFireNum*3;
                    float fixangle= angle*2/(fireballState.FireballFireNum-1);
                    for(int i = 1;i<=fireballState.FireballFireNum;i++){
                        GameObject attackObject = Instantiate(skill.skill,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg+angle));
                        angle-=fixangle;
                        attackObject.GetComponent<FireBall>().fly();
                    }
                }
                else{
                GameObject attackObject = Instantiate(skill.skill,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.GetComponent<FireBall>().fly();
                }
            }
        }
        else if(skill.skillname=="LightningBlast"){
            if(Closest!=null){
                useskill(skillnum);
                dir=Closest.transform.position-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                float distance = Vector3.Distance(firepoint.transform.position,Closest.transform.position);
                GameObject attackObject = Instantiate(skill.skill,(Closest.transform.position+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.transform.localScale=new Vector3(distance*2f/10f,0.25f,0.25f);
                attackObject.GetComponent<LightningBlast>().setTarget(Closest);
            }
        }
    }
    public void swapskill(int i,int j){
        skillpool temp = skillpools[i];
        skillpools[i]=skillpools[j];
        skillpools[j]=temp;
    }
    public void setFireBall(){
        int num=0;
        fireballState.FireEnable=true;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname==""){
                break;
            }
            num+=1;
        }
        skillpools[num].setskill(fireball,"FireBall",fireballState.Fireballcastspeed*playerState.playerCastspeed);
        setbutton(num,fireballSprite);
    }
    public void setLightningBlast(){
        int num=0;
        lightningblastState.LightningBlastEnable=true;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname==""){
                break;
            }
            num+=1;
        }
        skillpools[num].setskill(lightningblast,"LightningBlast",lightningblastState.LightningBlastcastspeed*playerState.playerCastspeed);
        setbutton(num,lightningblastSprite);
    }
    public void setMagicWeapon(){
        int num=0;
        magicweaponState.MagicWeaponEnable=true;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname == ("")){
                break;
            }
            num+=1;
        }
        skillpools[num].setskill(null,"MagicWeapon",magicweaponState.MagicWeaponDuration);
        setbutton(num,magicweaponSprite);
    }
    private void setbutton(int num,Sprite sprite){
        switch(num){
            case 0:
                skillImage_M1.sprite=sprite;
                skillImage_M1.color= new Color(255f,255f,255f,255f);
                skillImage_M1.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 1:
                skillImage_Q.sprite=sprite;
                skillImage_Q.color= new Color(255f,255f,255f,255f);
                skillImage_Q.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 2:
                skillImage_W.sprite=sprite;
                skillImage_W.color= new Color(255f,255f,255f,255f);
                skillImage_W.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 3:
                skillImage_E.sprite=sprite;
                skillImage_E.color= new Color(255f,255f,255f,255f);
                skillImage_E.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 4:
                skillImage_R.sprite=sprite;
                skillImage_R.color= new Color(255f,255f,255f,255f);
                skillImage_R.GetComponent<CanvasGroup>().interactable=true;
                break;
        }
    }
    private void useskill(int i){
        if(i==0){
            skillpools[0].iscooldowning=true;
            skillImage_M1.fillAmount=0;
        }
        else if(i==1){
            skillpools[1].iscooldowning=true;
            skillImage_Q.fillAmount=0;
        }
        else if(i==2){
            skillpools[2].iscooldowning=true;
            skillImage_W.fillAmount=0;
        }
        else if(i==3){
            skillpools[3].iscooldowning=true;
            skillImage_E.fillAmount=0;
        }
        else if(i==4){
            skillpools[4].iscooldowning=true;
            skillImage_R.fillAmount=0;
        }
    }
}
