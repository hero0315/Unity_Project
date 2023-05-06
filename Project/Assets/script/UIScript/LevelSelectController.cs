using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    private int skillCount;
    [SerializeField]private SkillController SkillController;
    public class skill{
        public skill(string name,Sprite sprite){
            skillname=name;
            skillSprite=sprite;
        }
        private string skillname;

        private Sprite skillSprite; 
        public Sprite GetskillSprite(){
            return skillSprite;
        }
    }
    
    List<skill> skillpools = new List<skill>();
    [System.Serializable]
    public class Select{
        [SerializeField]private GameObject SelectSkill;
        private skill Skill;
        private string description; 
        public void setSprite(Sprite sprite){
            SelectSkill.GetComponent<Image>().sprite=sprite;
        }
    }
    [SerializeField]
    List<Select> Selects = new List<Select>();
    public void setSelectsActive(){
        skillCount = SkillController.GetSkillCount();
        for(int i=0;i<skillCount;i++){
            skillpools.Add(new skill(SkillController.GetSkillName(i),SkillController.GetSkillSprite(i)));
        }
        foreach(Select select in Selects){
            select.setSprite(skillpools[Random.Range(0,skillCount-1)].GetskillSprite());
        }

    }

}
