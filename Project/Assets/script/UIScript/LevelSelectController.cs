using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    private int skillCount;
    [SerializeField] GameObject LevelSelect;
    [SerializeField]private SkillController SkillController;
    private int FireBallUpgradeNum = 4,LightningBlastUpgradeNum = 2;
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
        public int SelectRandom;
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
    Dictionary<int, int> selectRecord=new Dictionary<int, int>();
        public void setSelectsActive(){
        skillCount = SkillController.GetSkillCount();
        for(int i=0;i<skillCount;i++){
            skillpools.Add(new skill(SkillController.GetSkillName(i),SkillController.GetSkillSprite(i)));
        }
        List<int> selectthisround=new List<int>();
        foreach(Select select in Selects){
            skill _skill=skillpools[Random.Range(0,skillCount)];
            select.setskill(_skill);
            select.setSprite(_skill.GetskillSprite());
            switch (_skill.skillname){
                case "FireBall":
                    select.SelectRandom = Random.Range(1,FireBallUpgradeNum+1);
                    while(selectthisround.Contains(select.SelectRandom)){
                        select.SelectRandom = Random.Range(1,FireBallUpgradeNum+1);
                    }
                    selectthisround.Add(select.SelectRandom);
                    Addselectrecord(select.SelectRandom);
                    switch (select.SelectRandom){
                        case 1:
                            select.SkillDescript.text="FireBall Damage + 20";
                            break;
                        case 2:
                            select.SkillDescript.text="FireBall Pierce +1 Enemy";
                            break;
                        case 3:
                            select.SkillDescript.text="FireBall Fire +2 Project";
                            break;
                        case 4:
                            select.SkillDescript.text="FireBall Chain +2 Enemy";
                            break;
                    }
                    break;
                case"LightningBlast":
                    select.SelectRandom = Random.Range(11,LightningBlastUpgradeNum+11);
                    while(selectthisround.Contains(select.SelectRandom)){
                        select.SelectRandom = Random.Range(11,LightningBlastUpgradeNum+11);
                    }
                    selectthisround.Add(select.SelectRandom);
                    Addselectrecord(select.SelectRandom);
                    switch (select.SelectRandom){
                        case 11:
                            select.SkillDescript.text="Lightning Blast Damage + 20";
                            break;
                        case 12:
                            select.SkillDescript.text="Lightning Blast Hit to +1 Enemy";
                            break;
                    }
                    break;
            }
        }
    }
    public void LevelSelect1(){
        selectUpgrade(Selects[0].Skill.skillname,Selects[0].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect2(){
        selectUpgrade(Selects[1].Skill.skillname,Selects[1].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect3(){
        selectUpgrade(Selects[2].Skill.skillname,Selects[2].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    void selectUpgrade(string name,int selectRandom){
        switch (name){
                case "FireBall":
                    switch (selectRandom){
                        case 1:
                            playerState.playerFireballdamage+=20;
                            break;
                        case 2:
                            playerState.playerFireballpirece+=1;
                            break;
                        case 3:
                            playerState.playerFireballFireNum+=2;
                            break;
                        case 4:
                            playerState.playerFireballchainNum+=2;
                            break;
                    }
                    break;
                case"LightningBlast":
                switch (selectRandom){
                    case 11:
                        playerState.playerLightningBlastdamage+=15;
                        break;
                    case 12:
                        playerState.playerLightningBlastchainNum+=1;
                        break;
                    }
                    break;
            }
    }
    int Checkselectrecord(int serialNumber){
        if(serialNumber==1){
            return selectRecord[1];
        }
        else if(serialNumber==2){
            return selectRecord[2];
        }
        else if(serialNumber==3){
            return selectRecord[3];
        }
        else if(serialNumber==4){
            return selectRecord[4];
        }
        else{
            return (-1);
        }
    }
    void Addselectrecord(int serialNumber){
        if(!selectRecord.ContainsKey(serialNumber)){
            selectRecord.Add(serialNumber,1);
        }
        else{
            switch (serialNumber){
                case 1:
                    selectRecord[1]+=1;
                    break;
                case 2:
                    selectRecord[2]+=1;
                    break;
                case 3:
                    selectRecord[3]+=1;
                    break;
                case 4:
                    selectRecord[4]+=1;
                    break;
                case 11:
                    selectRecord[11]+=1;
                    break;
                case 12:
                    selectRecord[12]+=1;
                    break;
            }
        }
    }
}
