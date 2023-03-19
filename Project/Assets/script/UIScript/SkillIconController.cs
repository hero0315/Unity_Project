/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconController : MonoBehaviour
{
    [System.Serializable]
    public class Skills{
        public GameObject Key;
        public Image skillImage; 
        public string SkillName;
        public bool cooldowning=false;  
        public bool isusing=false;      
    }
    private string []skillname;
    public List<Skills> Skill;
    [SerializeField]GameObject player;
    void Start(){
        for(int i = 0;i<player.GetComponent<SkillController>().skillpools.Count;i++){
            skillname[i]=player.GetComponent<SkillController>().getskillname(i);
            for(int j=0;j<=Skill.Count;j++){
                if(skillname[i]==Skill[j].SkillName){
                    Skill[j].skillImage.fillAmount=1;
                    Skill[j].isusing=true;
                }
            } 
        }
           
    }
    void Update(){
        for(int i=0;i<Skill.Count;i++){
            if(Skill[i].isusing==true&&Skill[i].cooldowning==false){
                if(player.GetComponent<SkillController>().getcooldown(i)*Time.deltaTime;)
                Skill[i].skillImage.fillAmount-=1/player.GetComponent<SkillController>().getcooldown(i)*Time.deltaTime;
                Skill[i].cooldowning=true;
            }
            else if(Skill[i].cooldowning==true)
        }
    }
    
}
*/
