using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    [SerializeField]List<GameObject> SpinWeapons = new List<GameObject>();
    [SerializeField]List<GameObject> Weaponlsit = new List<GameObject>();
    [SerializeField]SkillController skillcontroller;
    List<GameObject> createWeapon = new List<GameObject>();
    float xpos=0f;
    float ypos=2.5f;
    public bool isusing=false;
    [SerializeField]float circlesize=1f;
    float z=0;
    void Update(){
        transform.rotation=Quaternion.Euler(0f,0f,z);
        z+=Time.deltaTime*120f;
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
                    createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z)*circlesize,Quaternion.Euler(0f,0f,0f),this.transform));
                    _weapon.SetActive(false);
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
                    _weapon.SetActive(false);
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
                    _weapon.SetActive(false);
                }
                xpos=2.5f;
                ypos=0;
                break;
            default:
                Debug.Log("over 6");
                break;
        }
    }
    public void usemagicweapon(float sec){
        foreach(GameObject _weapon in createWeapon){
            isusing=true;
            _weapon.SetActive(true);
            Invoke("disableweapon",sec);
        }
    }
    private void disableweapon(){
        foreach(GameObject _weapon in createWeapon){
            isusing=false;
            _weapon.SetActive(false);
        }
    }
}
