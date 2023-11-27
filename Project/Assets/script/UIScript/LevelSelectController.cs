using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] GameObject LevelSelect;
    [SerializeField] SkillController skillController;
    [SerializeField] GameObject spinWeapon;
    [SerializeField] Sprite fireballSprite;
    [SerializeField] Sprite lightningblastSprite;
    [SerializeField] Sprite MageicWeaponSprite;
    [SerializeField] Sprite FlameJetSprite;
    [SerializeField] Sprite WaterSplashSprite;
    [SerializeField] Sprite BloodExplodeSprite;
    [SerializeField] Sprite LightningStrikeSprite;
    [SerializeField] int SkillSlotleft=4;
    List<string> selectpool=new List<string>();
    [SerializeField]
    List<GameObject> selectobjs=new List<GameObject>();
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
    Dictionary<string, int> selectRecord=new Dictionary<string, int>();
    void Start(){
        if(fireballState.FireballEnable==false){
            selectpool.Add("getFireBall");
        }
        else{
            setFireBallUpgrade();
            SkillSlotleft-=1;
        }
        if(lightningblastState.LightningBlastEnable==false){
            selectpool.Add("getLightningBlast");
        }
        else{
            setLightningBlastUpgrade();
            SkillSlotleft-=1;
        }
        if(magicweaponState.MagicWeaponEnable==false){
            selectpool.Add("getMagicWeapon");
        }
        else{
            setMagicWeaponUpgrade();
            SkillSlotleft-=1;
        }
        if(FlameJetState.FlameJetEnable==false){
            selectpool.Add("getFlameJet");
        }
        else{
            setFlameJetUpgrade();
            SkillSlotleft-=1;
        }
        if(watersplashState.WaterSplashEnable==false){
            selectpool.Add("getWaterSplash");
        }
        else{
            setWaterSplashUpgrade();
            SkillSlotleft-=1;
        }
        if(BloodExplodeState.BloodExplodeEnable==false){
            selectpool.Add("getBloodExplode");
        }
        else{
            setBloodExplodeUpgrade();
            SkillSlotleft-=1;
        }
        if(LightningStrikeState.LightningStrikeEnable==false){
            selectpool.Add("getLightningStrike");
        }
        else{
            setLightningBlastUpgrade();
            SkillSlotleft-=1;
        }
    }
    public void levelup(){
        setSelectsActive();
        StartCoroutine(playstartanim());
    }
    IEnumerator playstartanim(){
        int i = 1;
        foreach(GameObject obj in selectobjs){
            obj.SetActive(true);
            obj.GetComponent<Animator>().enabled=true;
            Debug.Log("第"+i+"個播放");
            i++;
            yield return new WaitForSecondsRealtime(0.25f);
            obj.GetComponent<Button>().interactable=true;
        }
        StopCoroutine(playstartanim());
    }
    IEnumerator playstopanim(int n){
        selectobjs[n].GetComponent<Animator>().SetBool("Select",true);
        yield return new WaitForSecondsRealtime(0.2f);
        foreach(GameObject obj in selectobjs){
            obj.GetComponent<Animator>().SetTrigger("Selected");
            obj.GetComponent<Button>().interactable=false;
        }
        yield return new WaitForSecondsRealtime(0.4f);
        foreach(GameObject obj in selectobjs){
            obj.GetComponent<Animator>().enabled=false;
            obj.SetActive(false);
        }
        selectobjs[n].transform.localScale=new Vector3(1,1,1);
        selectobjs[n].transform.rotation=new Quaternion(0,0,0,0);
        eventController.depauseEvent.Invoke();
        StopCoroutine(playstopanim(n));
    }
    public void setSelectsActive(){
        List<int> selectthisround=new List<int>();
        int selectnum=0;
        foreach(Select select in Selects){
            while(true){
                select.SelectRandom = Random.Range(0,selectpool.Count);
                if(!selectthisround.Contains(select.SelectRandom)){
                    if(isUpgradeEnable(select.SelectRandom,selectnum)==true){ 
                        break;
                    }
                }
            }
            selectthisround.Add(select.SelectRandom);
            selectnum+=1;
        }
    }
    public void LevelSelect1(){
        UpgradeSkill(Selects[0].SelectRandom);
        Addselectrecord(Selects[0].SelectRandom);
        StartCoroutine(playstopanim(0));
    }
    public void LevelSelect2(){
        UpgradeSkill(Selects[1].SelectRandom);
        Addselectrecord(Selects[1].SelectRandom);
        StartCoroutine(playstopanim(1));
    }
    public void LevelSelect3(){
        UpgradeSkill(Selects[2].SelectRandom);
        Addselectrecord(Selects[2].SelectRandom);
        StartCoroutine(playstopanim(2));
    }
    void UpgradeSkill(int selectRandom){
            switch (selectpool[selectRandom]){
                case "getFireBall":
                    setFireBallUpgrade();
                    skillController.setFireBall();
                    SkillSlotleft-=1;
                    fireballState.FireballEnable=true;
                    break;
                case "FireBallDamage":
                    fireballState.Fireballdamage+=20;
                    break;
                case "FireballPierce":
                    fireballState.Fireballpierce+=1;
                    break;
                case "FireBallProject":
                    fireballState.FireballFireNum+=2;
                    break;
                case "FireBallChain":
                    fireballState.FireballchainNum+=1;
                    break;
                case "getLightningBlast":
                    setLightningBlastUpgrade();
                    skillController.setLightningBlast();
                    SkillSlotleft-=1;
                    lightningblastState.LightningBlastEnable=true;
                    break;
                case "LightningBlastDamage":
                    lightningblastState.LightningBlastdamage+=15;
                    break;
                case "LightningBlastHit":
                    lightningblastState.LightningBlastchainNum+=2;
                    break;
                case "LightningBlastHitRange":
                    lightningblastState.LightningBlastIncreaseRange+=0.2f;
                    break;
                case "LightningBlastAttackRange":
                    lightningblastState.LightningBlastAttaackRange+=0.1f;
                    break;
                case "getMagicWeapon":
                    setMagicWeaponUpgrade();
                    skillController.setMagicWeapon();
                    spinWeapon.GetComponent<SpinWeapon>().addWeapon();
                    magicweaponState.MagicWeaponEnable=true;
                    spinWeapon.SetActive(true);
                    SkillSlotleft-=1;
                    break;
                case "MagicWeaponDamage":
                    magicweaponState.MagicWeaponDamage+=10f;
                    break;
                case "MagicWeaponNum":
                    spinWeapon.GetComponent<SpinWeapon>().addWeapon();
                    break;
                case "getFlameJet":
                    setFlameJetUpgrade();
                    SkillSlotleft-=1;
                    skillController.setFlameJet();
                    FlameJetState.FlameJetEnable=true;
                    break;
                case "FlameJetDamage":
                    FlameJetState.FlameJetDamage+=10f;
                    break;
                case "getWaterSplash":
                    setWaterSplashUpgrade();
                    skillController.setWaterSplash();
                    SkillSlotleft-=1;
                    watersplashState.WaterSplashEnable=true;
                    break;
                case "WaterSplashDamage":
                    watersplashState.WaterSplashdamage+=20f;
                    break;
                case "getBloodExplode":
                    setBloodExplodeUpgrade();
                    SkillSlotleft-=1;
                    skillController.setBloodExplode();
                    BloodExplodeState.BloodExplodeEnable=true;
                    break;
                case "BloodExplodeDamage":
                    BloodExplodeState.BloodExplodeDamage+=10f;
                    break;
                case "getLightningStrike":
                    setLightningStrikeUpgrade();
                    skillController.setLightningStrike();
                    SkillSlotleft-=1;
                    LightningStrikeState.LightningStrikeEnable=true;
                    break;
                case "LightningStrikeDamage":
                    LightningStrikeState.LightningStrikedamage+=10f;
                    break;
            }
    }
    void Addselectrecord(int serialNumber){
        if(!selectRecord.ContainsKey(selectpool[serialNumber])){
            selectRecord.Add(selectpool[serialNumber],1);
        }
        else{
            selectRecord[selectpool[serialNumber]]+=1;
        }
    }
    bool isUpgradeEnable(int UpgradeNum,int selectnum){
        switch (selectpool[UpgradeNum]){
            case "getFireBall":
                if(fireballState.FireballEnable==true){
                    return false;
                }
                else{
                    Selects[selectnum].setSprite(fireballSprite);
                    Selects[selectnum].SkillDescript.text="Get FireBall Skill";
                    return true;
                }
            case "FireBallDamage":
                if(fireballState.FireballEnable==true){
                    Selects[selectnum].setSprite(fireballSprite);
                    Selects[selectnum].SkillDescript.text="FireBall Damage + 20";
                    return true;
                }
                else{
                    return false;
                }
            case "FireballPierce":
                if(fireballState.FireballEnable==true){
                    Selects[selectnum].setSprite(fireballSprite);
                    Selects[selectnum].SkillDescript.text="FireBall Pierce +1 Enemy";
                    return true;
                }
                else{
                    return false;
                }
            case "FireBallProject":
                if(fireballState.FireballEnable==true){
                    Selects[selectnum].setSprite(fireballSprite);
                    Selects[selectnum].SkillDescript.text="FireBall Fire +2 Project";
                    return true;
                }
                else{
                    return false;
                }
            case "FireBallChain":
                if(fireballState.FireballEnable==true){
                    Selects[selectnum].setSprite(fireballSprite);
                    Selects[selectnum].SkillDescript.text="FireBall Chain +1 Enemy";
                    return true;
                }
                else{
                    return false;
                }
            case "LightningBlastDamage":
                if(lightningblastState.LightningBlastEnable==true){
                    Selects[selectnum].setSprite(lightningblastSprite);
                    Selects[selectnum].SkillDescript.text="Lightning Blast Damage + 15";
                   return true; 
                }
                else{
                    return false;
                }
            case "getLightningBlast":
                if(lightningblastState.LightningBlastEnable==true){
                   return false; 
                }
                else{
                    Selects[selectnum].setSprite(lightningblastSprite);
                    Selects[selectnum].SkillDescript.text="Get LightningBlast Skill";
                    return true;
                }
            case "LightningBlastHit":
                if(lightningblastState.LightningBlastEnable==true){
                    Selects[selectnum].setSprite(lightningblastSprite);
                    Selects[selectnum].SkillDescript.text="Lightning Blast Hit to +2 Enemy";
                    return true; 
                }
                else{
                    return false;
                }
            case "LightningBlastHitRange":
                if(lightningblastState.LightningBlastEnable==true){
                    Selects[selectnum].setSprite(lightningblastSprite);
                    Selects[selectnum].SkillDescript.text="Lightning Blast +20% Range to Hit Enemy";
                    return true; 
                }
                else{
                    return false;
                }
            case "LightningBlastAttackRange":
                if(lightningblastState.LightningBlastEnable==true){
                    Selects[selectnum].setSprite(lightningblastSprite);
                    Selects[selectnum].SkillDescript.text="Lightning Blast +10% Attack Range";
                    return true; 
                }
                else{
                    return false;
                }
            case "getMagicWeapon":
                if(magicweaponState.MagicWeaponEnable==true){
                   return false; 
                }
                else{
                    Selects[selectnum].setSprite(MageicWeaponSprite);
                    Selects[selectnum].SkillDescript.text="Get MagicWeapon Skill";
                    return true;
            }
            case "MagicWeaponDamage":
                if(magicweaponState.MagicWeaponEnable==true){
                    Selects[selectnum].setSprite(MageicWeaponSprite);
                    Selects[selectnum].SkillDescript.text="Mageic Weapon +10 Damage";
                    return true;
                }
                else{
                    return false;
                }
            case "MagicWeaponNum":
                if(selectRecord.ContainsKey("MagicWeaponNum")){
                    if(selectRecord["MagicWeaponNum"]>=2||magicweaponState.MagicWeaponEnable==false){
                        return false;
                    }
                    else{
                        Selects[selectnum].setSprite(MageicWeaponSprite);
                        Selects[selectnum].SkillDescript.text="Mageic Weapon +2 Weapon";
                        return true;
                    }
                }
                else{
                    return false;
                }
            case "getFlameJet":
                if(FlameJetState.FlameJetEnable||SkillSlotleft<=0){
                   return false; 
                }
                else{
                    Selects[selectnum].setSprite(FlameJetSprite);
                    Selects[selectnum].SkillDescript.text="Get FlameJet Skill";
                    return true;
                }
            case "FlameJetDamage":
                if(FlameJetState.FlameJetEnable&&SkillSlotleft>0){
                    Selects[selectnum].setSprite(FlameJetSprite);
                    Selects[selectnum].SkillDescript.text="Flame Jet +10 Damage";
                    return true;
                }
                else{
                    return false;
                }
            case "getWaterSplash":
                if(watersplashState.WaterSplashEnable||SkillSlotleft<=0){
                   return false; 
                }
                else{
                    Selects[selectnum].setSprite(WaterSplashSprite);
                    Selects[selectnum].SkillDescript.text="Get Water Splash Skill";
                    return true;
                }
                case "WaterSplashDamage":
                if(watersplashState.WaterSplashEnable&&SkillSlotleft>0){
                    Selects[selectnum].setSprite(WaterSplashSprite);
                    Selects[selectnum].SkillDescript.text="Water Splash +5 Damage";
                    return true;
                }
                else{
                    return false;
                }
                case "getBloodExplode":
                    if(BloodExplodeState.BloodExplodeEnable||SkillSlotleft<=0){
                        return false; 
                    }
                    else{
                        Selects[selectnum].setSprite(BloodExplodeSprite);
                        Selects[selectnum].SkillDescript.text="Get Blood Explode Skill";
                        return true;
                    }
                case "BloodExplodeDamage":
                    if(BloodExplodeState.BloodExplodeEnable&&SkillSlotleft>0){
                        Selects[selectnum].setSprite(BloodExplodeSprite);
                        Selects[selectnum].SkillDescript.text="Blood Explode +10 Damage";
                        return true;
                    }
                    else{
                        return false;
                    }
                case "getLightningStrike":
                    if(LightningStrikeState.LightningStrikeEnable||SkillSlotleft<=0){
                        return false; 
                    }
                    else{
                        Selects[selectnum].setSprite(LightningStrikeSprite);
                        Selects[selectnum].SkillDescript.text="Get Lightning Strike Skill";
                        return true;
                    }
                case "LightningStrikeDamage":
                    if(LightningStrikeState.LightningStrikeEnable){
                        Selects[selectnum].setSprite(LightningStrikeSprite);
                        Selects[selectnum].SkillDescript.text="Lightning Strike +10 Damage";
                        return true;
                    }
                    else{
                        return false;
                    }
                default:
                    return false;
        }
    }
    void setFireBallUpgrade(){
        selectpool.Add("FireBallDamage");
        selectpool.Add("FireBallPierce");
        selectpool.Add("FireBallProject");
        selectpool.Add("FireBallChain");
        if(selectpool.Contains("getFireBall"))
            selectpool.Remove("getFireBall");
    }
    void setLightningBlastUpgrade(){
        selectpool.Add("LightningBlastDamage");
        selectpool.Add("LightningBlastHit");
        selectpool.Add("LightningBlastHitRange");
        selectpool.Add("LightningBlastAttackRange");
        if(selectpool.Contains("getLightningBlast"))
            selectpool.Remove("getLightningBlast");
    }
    void setMagicWeaponUpgrade(){
        selectpool.Add("MagicWeaponNum");
        selectpool.Add("MagicWeaponDamage");
        if(selectpool.Contains("getMagicWeapon"))
            selectpool.Remove("getMagicWeapon");
    }
    void setFlameJetUpgrade(){
        selectpool.Add("FlameJetDamage");
        if(selectpool.Contains("getFlameJet"))
            selectpool.Remove("getFlameJet");
    }
    void setWaterSplashUpgrade(){
        selectpool.Add("WaterSplashDamage");
        if(selectpool.Contains("getWaterSplash"))
            selectpool.Remove("getWaterSplash");
    }
    void setBloodExplodeUpgrade(){
        selectpool.Add("BloodExplodeDamage");
        if(selectpool.Contains("getBloodExplode"))
            selectpool.Remove("getBloodExplode");
    }
    void setLightningStrikeUpgrade(){
        selectpool.Add("LightningStrikeDamage");
        if(selectpool.Contains("getLightningStrike"))
            selectpool.Remove("getBLightningStrike");
    }
}
