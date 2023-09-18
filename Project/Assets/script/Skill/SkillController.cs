using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillController : MonoBehaviour
{
    public int MagicWeaponNum;
    public int FireballNum;
    public int LightningBlastNum;
    public int FlameJetNum;
    public int PlagueSlashnum;
    public int WaterSplashnum;
    public int BloodExplodenum;
    [SerializeField]private GameObject FireBallattacker;
    [SerializeField]private GameObject LightningBlastattacker;
    [SerializeField]private GameObject Spinweapon;
    [SerializeField]private GameObject FlameJetattacker;
    [SerializeField]private GameObject PlagueSlashattacker;
    [SerializeField]private GameObject WaterSplashattacker;
    [SerializeField]private GameObject BloodExplodeatacker;
    [SerializeField]public List<Image> skillImagepool;
    [SerializeField]private Image skillImage_0;
    [SerializeField]private Image skillImage_1;
    [SerializeField]private Image skillImage_2;
    [SerializeField]private Image skillImage_3;
    [SerializeField]private Image skillImage_4;
    [SerializeField]private Sprite magicweaponSprite;
    [SerializeField]private Sprite fireballSprite;
    [SerializeField]private Sprite lightningblastSprite;
    [SerializeField]private Sprite FlameJetSprite;
    [SerializeField]private Sprite PlagueSlashSprite;
    [SerializeField]private Sprite WaterSplashSprite;
    [SerializeField]private Sprite BloodExplodeSplashSprite;
    public List<string> skillpool;
    void Start(){
        for(int i=0;i<=4;i++){
            skillpool.Add("");
        }
        skillpool[0]="FireBall";
        skillImagepool.Add(skillImage_0);
        skillImagepool.Add(skillImage_1);
        skillImagepool.Add(skillImage_2);
        skillImagepool.Add(skillImage_3);
        skillImagepool.Add(skillImage_4);
        //setPlagueSlash();
        //setWaterSplash();
        //setBloodExplode();
    }
    public void setFireBall(){
        int num=0;
        FireBallattacker.SetActive(true);
        fireballState.FireballEnable=true;
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                break;
            }
            num=i;
        }
        skillpool[num]="FireBall";
        FireballNum=num;
        FireBallattacker.GetComponent<FireBallAttacker>().setFireballNum(num);
        setbutton(num,fireballSprite);
    }
    public void setLightningBlast(){
        
        int num=0;
        LightningBlastattacker.SetActive(true);
        lightningblastState.LightningBlastEnable=true;
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            } 
        }
        skillpool[num]="LightningBlast";
        LightningBlastNum=num;
        LightningBlastattacker.GetComponent<LightningBlastAttacker>().setLightningBlastNum(num);
        setbutton(num,lightningblastSprite);
    }
    public void setMagicWeapon(){
        int num=0;
        magicweaponState.MagicWeaponEnable=true;
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            }
        }
        skillpool[num]="MagicWeapon";
        MagicWeaponNum=num;
        Spinweapon.GetComponent<SpinWeapon>().setMagicWeaponNum(num);
        setbutton(num,magicweaponSprite);
    }
    public void setFlameJet(){
        int num=0;
        FlameJetState.FlameJetEnable=true;
        FlameJetattacker.SetActive(true);
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            }
        }
        skillpool[num]="FlameJet";
        FlameJetNum=num;
        FlameJetattacker.GetComponent<FlameJetAttacker>().setFlameJetNum(num);
        setbutton(num,FlameJetSprite);
    }
    public void setPlagueSlash(){
        int num=0;
        plagueslashState.PlagueSlashEnable=true;
        PlagueSlashattacker.SetActive(true);
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            }
        }
        skillpool[num]="PlagueSlash";
        PlagueSlashnum=num;
        PlagueSlashattacker.GetComponent<PlagueSlashAttacker>().setPlagueSlashnum(num);
        setbutton(num,PlagueSlashSprite);
    }
    public void setWaterSplash(){
        int num=0;
        watersplashState.WaterSplashEnable=true;
        WaterSplashattacker.SetActive(true);
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            }
        }
        skillpool[num]="WaterSplash";
        WaterSplashnum=num;
        WaterSplashattacker.GetComponent<WaterSplashAttacker>().setWaterSplashNum(WaterSplashnum);
        setbutton(num,WaterSplashSprite);
    }
    public void setBloodExplode(){
        int num=0;
        BloodExplodeState.BloodExplodeEnable=true;
        BloodExplodeatacker.SetActive(true);
        for(int i=0;i<=4;i++){
            if(skillpool[i]==""){
                num=i;
                break;
            }
        }
        skillpool[num]="BloodExplode";
        BloodExplodenum=num;
        BloodExplodeatacker.GetComponent<BloodExplodeAttacker>().setBloodExplodeNum(BloodExplodenum);
        setbutton(num,BloodExplodeSplashSprite);
    }
    private void setbutton(int num,Sprite sprite){
        switch(num){
            case 0:
                skillImage_0.sprite=sprite;
                skillImage_0.color= new Color(255f,255f,255f,255f);
                skillImage_0.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 1:
                skillImage_1.sprite=sprite;
                skillImage_1.color= new Color(255f,255f,255f,255f);
                skillImage_1.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 2:
                skillImage_2.sprite=sprite;
                skillImage_2.color= new Color(255f,255f,255f,255f);
                skillImage_2.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 3:
                skillImage_3.sprite=sprite;
                skillImage_3.color= new Color(255f,255f,255f,255f);
                skillImage_3.GetComponent<CanvasGroup>().interactable=true;
                break;
            case 4:
                skillImage_4.sprite=sprite;
                skillImage_4.color= new Color(255f,255f,255f,255f);
                skillImage_4.GetComponent<CanvasGroup>().interactable=true;
                break;
        }
    }
}
