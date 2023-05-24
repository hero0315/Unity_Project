using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    [SerializeField]List<GameObject> SpinWeapons = new List<GameObject>();
    List<GameObject> createWeapon = new List<GameObject>();
    Vector3 currentEulerAngles;
    float spinSpeed;
    float xpos;
    float ypos=2.5f;
    void Start(){
        /*
        foreach(GameObject weapon in SpinWeapons){
            createWeapon.Add(Instantiate(weapon,new Vector3(transform.position.x,transform.position.y+2.5f,transform.position.z),Quaternion.identity,this.transform));
        }
        */
    }
    void Update(){
         foreach(GameObject _weapon in SpinWeapons){
            currentEulerAngles+= new Vector3(0,0,-1)*Time.deltaTime*spinSpeed;
            this.transform.localEulerAngles = currentEulerAngles;
         }
    }
    
    public void addWeapon(GameObject weapon){   
        SpinWeapons.Add(weapon);
        foreach(GameObject _weapon in createWeapon){
                    Destroy(_weapon.gameObject);
        }
        createWeapon.Clear();
        switch(SpinWeapons.Count){
            case 1:
                foreach(GameObject _weapon in SpinWeapons){
                    createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+2.5f,transform.position.z),Quaternion.identity,this.transform));
                }
                ypos=2.5f;
                xpos=0;
                spinSpeed=120f;
                break;
            case 2:
                foreach(GameObject _weapon in SpinWeapons){
                    createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                    ypos=0-ypos;
                }
                ypos=2.5f;
                xpos=0;
                spinSpeed=100;
                Debug.Break();
                break;
            case 3:
                xpos=-2.165f;
                foreach(GameObject _weapon in SpinWeapons){
                    if(ypos>0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+2.5f,transform.position.z),Quaternion.identity,this.transform));
                        ypos=-1.25f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        xpos=0-xpos;
                    }
                
                }
                ypos=2.5f;
                xpos=0;
                spinSpeed=80;
                Debug.Break();
                break;
            case 4:
            xpos=1.768f;
            ypos=1.768f;
                foreach(GameObject _weapon in SpinWeapons){
                    if(xpos>0&&ypos>0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=-1.768f;
                    }
                    else if(xpos>0&&ypos<0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        xpos=-1.768f;
                        ypos=1.768f;
                    }
                    else if(xpos<0&&ypos>0){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        xpos=-1.768f;
                        ypos=-1.768f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                    }
                
                }
                ypos=2.5f;
                xpos=0;
                spinSpeed=70;
                Debug.Break();
                break;
            case 5:
                foreach(GameObject _weapon in SpinWeapons){
                    if(ypos==2.5f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+2.5f,transform.position.z),Quaternion.identity,this.transform));
                        ypos=0.772f;
                        xpos=2.378f;
                    }
                    else if(ypos==0.772f&&xpos==2.378f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=0.772f;
                        xpos=-2.378f;
                    }
                    else if(ypos==0.772f&&xpos==-2.378f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        xpos=-2.0225f;
                        ypos=-1.47f;
                    }
                    else if(ypos==-1.47f&&xpos==-2.0225f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        xpos=2.0225f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                    }
                }
                ypos=2.5f;
                xpos=0;
                spinSpeed=60;
                Debug.Break();
                break;
            case 6:
                foreach(GameObject _weapon in SpinWeapons){
                    if(ypos==2.5f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=-2.5f;
                    }
                    else if(ypos==-2.5f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=1.25f;
                        xpos=2.165f;
                    }
                    else if(ypos==1.25f&&xpos==2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=1.25f;
                        xpos=-2.165f;
                    }
                    else if(ypos==1.25f&&xpos==-2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=-1.25f;
                        xpos=2.165f;
                    }
                    else if(ypos==-1.25f&&xpos==2.165f){
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                        ypos=-1.25f;
                        xpos=-2.165f;
                    }
                    else{
                        createWeapon.Add(Instantiate(_weapon,new Vector3(transform.position.x+xpos,transform.position.y+ypos,transform.position.z),Quaternion.identity,this.transform));
                    }
                }
                xpos=2.5f;
                ypos=0;
                spinSpeed=50;
                Debug.Break();
                break;
            default:
                Debug.Log("over 6");
                break;
        }
    }
}
