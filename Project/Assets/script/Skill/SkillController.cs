using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private GameObject firepoint;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject notInRange;
    private Vector3 mousepos;
    [SerializeField]private Camera cam;
    [System.Serializable]
    public class skillpool{
        public GameObject skill;
        public string skillname;
        public string buttonName;
        [System.NonSerialized]
        public float cooldown;
        public float spellcastspeed=1;
        public GameObject SkillIcon;
        public Image skillImage; 
        [System.NonSerialized]
        public bool iscooldowning=false;
    }
    [SerializeField]
    private List<skillpool> skillpools;
    public string GetSkillName(int num){
        return skillpools[num].skillname;
    }
    public Sprite GetSkillSprite(int num){
        return skillpools[num].skillImage.sprite;
    }
    public int GetSkillCount(){
        return skillpools.Count;
    }
    public void setnotInRange(){
        notInRange.SetActive(false);
    }
    void Start(){
        foreach(skillpool skill in skillpools){
            skill.cooldown=playerState.playerCastspeed*skill.spellcastspeed;
        }
    }
    void Update()
    {
            if(Input.GetButton("mouse1")&&skillpools[0].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[0]);
                skillpools[0].iscooldowning=true;
                skillpools[0].skillImage.fillAmount=0;
            }
            else{
                skillpools[0].skillImage.fillAmount+= 1/ skillpools[0].cooldown*Time.deltaTime;
                if(skillpools[0].skillImage.fillAmount>=1){
                    skillpools[0].iscooldowning=false;
                }
            }
            if(Input.GetButton("Q")&&skillpools[1].iscooldowning==false){
                mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                Attack(skillpools[1]);
                skillpools[1].iscooldowning=true;
                skillpools[1].skillImage.fillAmount=0;
            }
            else{
                skillpools[1].skillImage.fillAmount+= 1/ skillpools[1].cooldown*Time.deltaTime;
                if(skillpools[1].skillImage.fillAmount>=1){
                    skillpools[1].iscooldowning=false;
                }
            }
    }
    private void Attack(skillpool skill){
        if(skill.skillname=="Fireball"){
            dir = mousepos-firepoint.transform.position;
            firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
            if(playerState.playerFireballFireNum>1){
                float angle=playerState.playerFireballFireNum*10;
                float fixangle= angle*2/(playerState.playerFireballFireNum-1);
                for(int i = 1;i<=playerState.playerFireballFireNum;i++){
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
            Vector3 Closest=nearbyDetect.GetComponent<playerNearBy>().getClosest(mousepos);
            if(Vector3.Distance(mousepos,firepoint.transform.position)>4.2f){
                notInRange.SetActive(true);
                Invoke("setnotInRange",0.5f);
            }
            if(Closest==Vector3.zero){
                float scale= (Vector3.Distance(mousepos,firepoint.transform.position)/2f);
                Vector3 genpos= new Vector3(((mousepos.x-firepoint.transform.position.x)/scale)/2+firepoint.transform.position.x,((mousepos.y-firepoint.transform.position.y)/scale)/2+firepoint.transform.position.y,0);
                dir = mousepos-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                float distance = 2f;
                GameObject attackObject = Instantiate(skill.skill,genpos,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.transform.localScale=new Vector3((float)distance*2f/10f,0.25f,0.25f);
            }
            else{
                dir=Closest-firepoint.transform.position;
                firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
                double distance = Vector3.Distance(firepoint.transform.position,Closest);
                GameObject attackObject = Instantiate(skill.skill,(Closest+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                attackObject.transform.localScale=new Vector3((float)distance*2/10,(float)0.25,(float)0.25);
            }
        }
    }
    
}
