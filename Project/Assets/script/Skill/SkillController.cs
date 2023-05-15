using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [SerializeField]private GameObject firepoint;
    private Vector3 mousepos;
    [SerializeField]private Camera cam;
    [System.Serializable]
    public class skillpool{
        public GameObject skill;
        public string skillname;
        public float projectforce=3f;
        public float spellcastspeed=1;
        public float fixangle=0;
        public string buttonName;
        [System.NonSerialized]
        public float cooldown;
        public GameObject SkillIcon;
        public Image skillImage; 
        [System.NonSerialized]
        public bool iscooldowning=false;
        public string type;
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
    void Start(){
        foreach(skillpool skill in skillpools){
            skill.cooldown=playerState.playerCastspeed*skill.spellcastspeed;
        }
    }
    void Update()
    {
            foreach(skillpool skill in skillpools){
                if(Input.GetButton(skill.buttonName)&&skill.iscooldowning==false){
                    mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                    Attack(skill);
                    skill.iscooldowning=true;
                    skill.skillImage.fillAmount=0;
                }
                else if(skill.iscooldowning==true){
                    skill.skillImage.fillAmount+= 1/ skill.cooldown*Time.deltaTime;
                    if(skill.skillImage.fillAmount>=1){
                        skill.iscooldowning=false;
                    }
                }
        }
    }
    private void Attack(skillpool skill){
        if(skill.type=="project"){
        Vector3 dir = mousepos-firepoint.transform.position;
        firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        GameObject attackObject = Instantiate(skill.skill,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg+skill.fixangle));
        Rigidbody2D rb = attackObject.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.up*skill.projectforce,ForceMode2D.Impulse);
        }
        else if(skill.type=="electric"){
        Vector3 dir = mousepos-firepoint.transform.position;
        firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        double length = Math.Sqrt(Math.Pow(firepoint.transform.position.x-mousepos.x,2)+Math.Pow(firepoint.transform.position.y-mousepos.y,2));
        GameObject attackObject = Instantiate(skill.skill,(mousepos+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg+skill.fixangle));
        attackObject.transform.localScale=new Vector3((float)length*2/10,(float)0.25,(float)0.25);
        }
    }
}
