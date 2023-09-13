using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    [SerializeField]List<GameObject> SpinWeapons = new List<GameObject>();
    [SerializeField]List<GameObject> Weaponlsit = new List<GameObject>();
    List<GameObject> createWeapon = new List<GameObject>();
    [SerializeField]SkillController skillController;
    float xpos=0f;
    float ypos=2.5f;
    float z=0;
    float timer=0;
    int MagicWeaponNum;
    bool cancooldown=false;
    public void setMagicWeaponNum(int num){
       MagicWeaponNum=num;
    }
    void Update(){
        transform.rotation=Quaternion.Euler(0f,0f,z);
        z+=Time.deltaTime*120f;
        timer+=Time.deltaTime;
        if(magicweaponState.MagicWeaponEnable&&magicweaponState.MagicWeaponusing==false){
            foreach (GameObject Weapon in createWeapon)
            {  
                Weapon.SetActive(true);
            }
            skillController.skillImagepool[MagicWeaponNum].fillAmount=0;
            magicweaponState.MagicWeaponusing=true;
            Invoke("setunActive",magicweaponState.MagicWeaponDuration);
        }
        else if(magicweaponState.MagicWeaponEnable&&magicweaponState.MagicWeaponusing&&cancooldown==true){
            skillController.skillImagepool[MagicWeaponNum].fillAmount+= (1/ magicweaponState.MagicWeaponCoolDown*Time.deltaTime);
            if(skillController.skillImagepool[MagicWeaponNum].fillAmount>=1){
                magicweaponState.MagicWeaponusing=false;
                cancooldown=false;
            }
        }
    }
    void setunActive(){
        foreach (GameObject Weapon in createWeapon)
        {
            magicweaponState.MagicWeaponusing=true;
            cancooldown=true;
            Weapon.SetActive(false);
        }
    }
    
    public void addWeapon(){  
        SpinWeapons.Add(Weaponlsit[Random.Range(0,Weaponlsit.Count)]);
        SpinWeapons.Add(Weaponlsit[Random.Range(0,Weaponlsit.Count)]);
        foreach(GameObject _weapon in createWeapon){
            Destroy(_weapon.gameObject);
        }
        createWeapon.Clear();
        switch(SpinWeapons.Count){
            case 2:
                foreach(GameObject _weapon in SpinWeapons){
                    createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                    ypos=0-ypos;
                }
                ypos=2.5f;
                xpos=0f;
                break;
            case 4:
            xpos=1.768f;
            ypos=1.768f;
                foreach(GameObject _weapon in SpinWeapons){
                    if(xpos>0&&ypos>0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=-1.768f;
                    }
                    else if(xpos>0&&ypos<0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        xpos=-1.768f;
                        ypos=1.768f;
                    }
                    else if(xpos<0&&ypos>0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        xpos=-1.768f;
                        ypos=-1.768f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                    }
                }
                ypos=2.5f;
                xpos=0;
                break;
            case 6:
                foreach(GameObject _weapon in SpinWeapons){
                    if(ypos==2.5f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=-2.5f;
                    }
                    else if(ypos==-2.5f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=1.25f;
                        xpos=2.165f;
                    }
                    else if(ypos==1.25f&&xpos==2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=1.25f;
                        xpos=-2.165f;
                    }
                    else if(ypos==1.25f&&xpos==-2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=-1.25f;
                        xpos=2.165f;
                    }
                    else if(ypos==-1.25f&&xpos==2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                        ypos=-1.25f;
                        xpos=-2.165f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.Euler(0f,0f,0f),this.transform));
                    }
                }
                xpos=2.5f;
                ypos=0;
                break;
            default:
                Debug.Log("over 6");
                break;
        }
    }
}
