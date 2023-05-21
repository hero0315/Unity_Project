using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] GameObject LevelSelect;
    [SerializeField] Sprite fireballSprite;
    [SerializeField] Sprite lightningblastSprite;
    private int FireBallUpgradeNum = 4,LightningBlastUpgradeNum = 4;
    [System.Serializable]
    public class Select{
        [SerializeField]private GameObject SelectSkill;
        [SerializeField]public TextMeshProUGUI SkillDescript;
        public int SelectRandom;
   
        public void setSprite(Sprite sprite){
            SelectSkill.GetComponent<Image>().sprite=sprite;
        }
    }
    [SerializeField]
    List<Select> Selects = new List<Select>();
    Dictionary<int, int> selectRecord=new Dictionary<int, int>();
    public void setSelectsActive(){
        List<int> selectthisround=new List<int>();
        foreach(Select select in Selects){
            select.SelectRandom = Random.Range(1,LightningBlastUpgradeNum+FireBallUpgradeNum+1);
            while(selectthisround.Contains(select.SelectRandom)){
                select.SelectRandom = Random.Range(1,LightningBlastUpgradeNum+FireBallUpgradeNum+1);
            }
            selectthisround.Add(select.SelectRandom);
            Addselectrecord(select.SelectRandom);
                switch (select.SelectRandom){
                    case 1:
                        select.setSprite(fireballSprite);
                        select.SkillDescript.text="FireBall Damage + 20";
                        break;
                    case 2:
                        select.setSprite(fireballSprite);
                        select.SkillDescript.text="FireBall Pierce +1 Enemy";
                        break;
                    case 3:
                        select.setSprite(fireballSprite);
                        select.SkillDescript.text="FireBall Fire +2 Project";
                        break;
                    case 4:
                        select.setSprite(fireballSprite);
                        select.SkillDescript.text="FireBall Chain +1 Enemy";
                        break;
                    case 5:
                        select.setSprite(lightningblastSprite);
                        select.SkillDescript.text="Lightning Blast Damage + 15";
                        break;
                    case 6:
                        select.setSprite(lightningblastSprite);
                        select.SkillDescript.text="Lightning Blast Hit to +2 Enemy";
                        break;
                    case 7:
                        select.setSprite(lightningblastSprite);
                        select.SkillDescript.text="Lightning Blast +20% Range to Hit Enemy";
                        break;
                    case 8:
                        select.setSprite(lightningblastSprite);
                        select.SkillDescript.text="Lightning Blast +10% Attack Range";
                        break;
                }
        }
    }
    public void LevelSelect1(){
        selectUpgrade(Selects[0].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect2(){
        selectUpgrade(Selects[1].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect3(){
        selectUpgrade(Selects[2].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    void selectUpgrade(int selectRandom){
            switch (selectRandom){
                case 1:
                    fireballState.Fireballdamage+=20;
                    break;
                case 2:
                    fireballState.Fireballpirece+=1;
                    break;
                case 3:
                    fireballState.FireballFireNum+=2;
                    break;
                case 4:
                    fireballState.FireballchainNum+=1;
                    break;
                case 5:
                    lightningblastState.LightningBlastdamage+=15;
                    break;
                case 6:
                    lightningblastState.LightningBlastchainNum+=2;
                    break;
                case 7:
                    lightningblastState.LightningBlastIncreaseRange+=0.2f;
                    break;
                case 8:
                    lightningblastState.LightningBlastAttaackRange+=0.1f;
                    break;

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
                case 5:
                    selectRecord[5]+=1;
                    break;
                case 6:
                    selectRecord[6]+=1;
                    break;
                case 7:
                    selectRecord[7]+=1;
                    break;
                case 8:
                    selectRecord[8]+=1;
                    break;
            }
        }
    }
}
