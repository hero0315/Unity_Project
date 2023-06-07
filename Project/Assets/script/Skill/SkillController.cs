using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private GameObject firepoint;
    [SerializeField]private GameObject SpinWeapon;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject notInRange;
    [SerializeField]private GameObject fireball;
    [SerializeField]private GameObject lightningblast;
    private Vector3 mousepos;
    [SerializeField]private Camera cam;
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
    public int GetSkillCount(){
        return skillpools.Count;
    }
    public void setnotInRange(){
        notInRange.SetActive(false);
    }
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
            if(Input.GetButton("Q")&&skillpools[1]!=null&&skillpools[1].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[1]);
                skillpools[1].iscooldowning=true;
                skillImage_Q.fillAmount=0;
            }
            else{
                skillImage_Q.fillAmount+= (1/ skillpools[1].spellcastspeed*Time.deltaTime);
                if(skillImage_Q.fillAmount>=1){
                    skillpools[1].iscooldowning=false;
                }
            }
            if(Input.GetButton("W")&&skillpools[2]!=null&&skillpools[2].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[2]);
                skillpools[2].iscooldowning=true;
                skillImage_W.fillAmount=0;
            }
            else{
                skillImage_W.fillAmount+= (1/ skillpools[2].spellcastspeed*Time.deltaTime);
                if(skillImage_W.fillAmount>=1){
                    skillpools[2].iscooldowning=false;
                }
            }
            if(Input.GetButton("E")&&skillpools[3]!=null&&skillpools[3].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[3]);
                skillpools[3].iscooldowning=true;
                skillImage_E.fillAmount=0;
            }
            else{
                skillImage_E.fillAmount+= (1/ skillpools[3].spellcastspeed*Time.deltaTime);
                if(skillImage_E.fillAmount>=1){
                    skillpools[3].iscooldowning=false;
                }
            }
            if(Input.GetButton("R")&&skillpools[4]!=null&&skillpools[4].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[4]);
                skillpools[4].iscooldowning=true;
                skillImage_R.fillAmount=0;
            }
            else{
                skillImage_R.fillAmount+= (1/ skillpools[4].spellcastspeed*Time.deltaTime);
                if(skillImage_R.fillAmount>=1){
                    skillpools[4].iscooldowning=false;
                }
            }
    }
    private void Attack(skillpool skill){
        Resources.UnloadUnusedAssets ();
        if(skill.skillname=="FireBall"){
            dir = mousepos-firepoint.transform.position;
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
        else if(skill.skillname=="LightningBlast"){
            mousepos.z=0;
            GameObject Closest=nearbyDetect.GetComponent<playerNearBy>().getClosest(mousepos);
            if(Vector3.Distance(mousepos,firepoint.transform.position)>3.5f*lightningblastState.LightningBlastAttaackRange){
                nearbyDetect.GetComponent<CircleCollider2D>().radius=1.4f*lightningblastState.LightningBlastAttaackRange;
                notInRange.transform.localScale=new Vector3(0.175f*lightningblastState.LightningBlastAttaackRange,0.215f*lightningblastState.LightningBlastAttaackRange,1f);
                notInRange.SetActive(true);
                Invoke("setnotInRange",0.4f);
            }
            if(Closest==null){
                float scale= (Vector3.Distance(mousepos,firepoint.transform.position)/2f);
                Vector3 genpos= new Vector3(((mousepos.x-firepoint.transform.position.x)/scale)/2+firepoint.transform.position.x,((mousepos.y-firepoint.transform.position.y)/scale)/2+firepoint.transform.position.y,0);
                dir = mousepos-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                GameObject attackObject = Instantiate(skill.skill,genpos,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.transform.localScale=new Vector3(4f/10f,0.25f,0.25f);
            }
            else{
                dir=Closest.transform.position-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                float distance = Vector3.Distance(firepoint.transform.position,Closest.transform.position);
                GameObject attackObject = Instantiate(skill.skill,(Closest.transform.position+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.transform.localScale=new Vector3(distance*2f/10f,0.25f,0.25f);
                attackObject.GetComponent<LightningBlast>().setTarget(Closest);
            }
        }
        else if(skill.skillname=="MagicWeapon"&&SpinWeapon.GetComponent<SpinWeapon>().isusing==false){
            SpinWeapon.GetComponent<SpinWeapon>().usemagicweapon(magicweaponState.MagicWeaponDuration);
        }
    }
    public void swapskill(int i,int j){
        skillpool temp = skillpools[i];
        skillpools[i]=skillpools[j];
        skillpools[j]=temp;
    }
    public void setFireBall(){
        int num=0;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname==""){
                num=skillpools.BinarySearch(_skillpool);
                break;
            }
        }
        skillpools[num].setskill(fireball,"FireBall",fireballState.Fireballcastspeed*playerState.playerCastspeed);
        setbutton(num,fireballSprite);
    }
    public void setLightningBlast(){
        int num=0;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname==""){
                num=skillpools.BinarySearch(_skillpool);
                break;
            }
        }
        skillpools[num].setskill(lightningblast,"LightningBlast",lightningblastState.LightningBlastcastspeed*playerState.playerCastspeed);
        setbutton(num,lightningblastSprite);
    }
    public void setMagicWeapon(){
        int num=0;
        foreach(skillpool _skillpool in skillpools){
            if(_skillpool.skillname == ("")){
                num=skillpools.BinarySearch(_skillpool);
                break;
            }
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
}
