using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    private int skillCount;
    [SerializeField] GameObject LevelSelect;
    [SerializeField] GameObject Fireball;
    [SerializeField] GameObject LightningBlast;
    [SerializeField]private SkillController SkillController;
    public class skill{
        [SerializeField]
        public GameObject skillObject;
        public skill(string name,Sprite sprite){
            skillname=name;
            skillSprite=sprite;
        }
        public string skillname;

        private Sprite skillSprite; 
        public Sprite GetskillSprite(){
            return skillSprite;
        }
    }
    
    List<skill> skillpools = new List<skill>();
    [System.Serializable]
    public class Select{
        [SerializeField]private GameObject SelectSkill;
        [SerializeField]public Text SkillDescript;
        public skill Skill;
        public void setSprite(Sprite sprite){
            SelectSkill.GetComponent<Image>().sprite=sprite;
        }
        public void setskill(skill skill){
            Skill=skill;
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
            skill _skill=skillpools[Random.Range(0,skillCount)];
            select.setskill(_skill);
            select.setSprite(_skill.GetskillSprite());
            switch (_skill.skillname){
                case "Fireball":
                    select.SkillDescript.text=Fireball.GetComponent<FireBall>().Upgrade1Descript();
                    break;
                case"LightningBlast":
                    break;
            }
        }
    }
    public void LevelSelect1(){
        string name=Selects[0].Skill.skillname;
        switch (name){
                case "Fireball":
                    Fireball.GetComponent<FireBall>().Upgrade1();
                    break;
                case"LightningBlast":
                    break;
            }
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect2(){
        string name=Selects[1].Skill.skillname;
        switch (name){
                case "Fireball":
                        Fireball.GetComponent<FireBall>().Upgrade1();
                    break;
                case"LightningBlast":
                    break;
            }
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect3(){
        string name=Selects[2].Skill.skillname;
        switch (name){
                case "Fireball":
                    Fireball.GetComponent<FireBall>().Upgrade1();
                    break;
                case"LightningBlast":
                    break;
            }
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
}
