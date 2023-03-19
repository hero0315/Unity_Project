using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [SerializeField]private GameObject firepoint;
    private Vector2 mousepos;
    [SerializeField]private Camera cam;
    [System.Serializable]
    public class skillpool{
        public GameObject skill;
        public float projectforce=3f;
        public float spellcastspeed=1;
        public float fixangle=0;
        public string buttonName;
        public float cooldown;
        public GameObject SkillIcon;
        public Image skillImage; 
        public bool iscooldowning=false;
    }
    public List<skillpool> skillpools;
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
                    Fireproject(skill);
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
    void Fireproject(skillpool skill){
        Vector2 dir = mousepos-(Vector2)firepoint.transform.position;
        firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        GameObject projectile = Instantiate(skill.skill,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f+90f+skill.fixangle));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.up*skill.projectforce,ForceMode2D.Impulse);
    }

}
