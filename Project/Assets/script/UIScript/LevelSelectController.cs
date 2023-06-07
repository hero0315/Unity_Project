using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] GameObject LevelSelect;
    [SerializeField] GameObject spinWeapon;
    [SerializeField] Sprite fireballSprite;
    [SerializeField] Sprite lightningblastSprite;
    [SerializeField] Sprite MageicWeaponSprite;
    private int UpgradeNum = 10;
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
            select.SelectRandom = Random.Range(1,UpgradeNum+1);
            while(true){
                if(isUpgradeEnable(select.SelectRandom)&&!selectthisround.Contains(select.SelectRandom)){
                    break;
                }
                Debug.Log(select.SelectRandom);
                select.SelectRandom = Random.Range(1,UpgradeNum+1);
            }
            selectthisround.Add(select.SelectRandom);
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
                    case 9:
                        select.setSprite(MageicWeaponSprite);
                        select.SkillDescript.text="Mageic Weapon Damage +10";
                        break;
                    case 10:
                        select.setSprite(MageicWeaponSprite);
                        select.SkillDescript.text="Mageic Weapon +2 Weapon";
                        break;
                }
        }
    }
    public void LevelSelect1(){
        UpgradeSkill(Selects[0].SelectRandom);
        Addselectrecord(Selects[0].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect2(){
        UpgradeSkill(Selects[1].SelectRandom);
        Addselectrecord(Selects[1].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    public void LevelSelect3(){
        UpgradeSkill(Selects[2].SelectRandom);
        Addselectrecord(Selects[2].SelectRandom);
        Time.timeScale = 1;
        LevelSelect.SetActive(false);
    }
    void UpgradeSkill(int selectRandom){
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
                case 9:
                    magicweaponState.MagicWeaponDamage+=10f;
                    break;
                case 10:
                    spinWeapon.GetComponent<SpinWeapon>().addWeapon();
                    break;

            }
    }
    void Addselectrecord(int serialNumber){
        if(!selectRecord.ContainsKey(serialNumber)){
            selectRecord.Add(serialNumber,1);
        }
        else{
            selectRecord[serialNumber]+=1;
        }
    }
    bool isUpgradeEnable(int serialNumber){
        switch (serialNumber){
            case 1:
                return true;
            case 2:
                return true;
            case 3:
                return true;
            case 4:
                return true;
            case 5:
                return true;
            case 6:
                return true;
            case 7:
                return true;
            case 8:
                return true;
            case 9:
                if(!selectRecord.ContainsKey(10)){
                    return false;
                }
                else{
                    return true;
                }
            case 10:
                if(selectRecord.ContainsKey(10)){
                    if(selectRecord[10]>=3){
                        return false;
                    }
                    else{
                        return true;
                    }
                }
                else{
                    return true;
                }
            default:
                return false;
        }
    }
}
