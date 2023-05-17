using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class LightningBlast : MonoBehaviour , Attack
{
    [SerializeField]int UpgradeNum=4;
    private List<GameObject> detect = new List<GameObject>();
    GameObject closest;
    public int lastchainNum;
    bool firstattack=true;
    void Start()
    {
        Invoke("Destroy",0.5f);
        if(firstattack==true){
            lastchainNum=playerState.playerLightningBlastchainNum;
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Add(collider.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Remove(collider.gameObject);
        }
    }
    
    public Vector3 getClosest(GameObject collider){
        float distance=100; 
        closest=null;
        foreach (GameObject monster in detect){
            if(Vector3.Distance(monster.transform.position, collider.transform.position)==0){
                continue;
            }
            else if(Vector3.Distance(monster.transform.position, collider.transform.position)<distance&&!monster.TryGetComponent<Markchained>(out Markchained hinge)){
                closest=monster;
                distance=Vector3.Distance(monster.transform.position, collider.transform.position);
            }
        }
        if(closest==null){
            return Vector3.zero;
        }
        else{
            closest.AddComponent<Markchained>();
            return closest.transform.position;
        }
    }
    public int getUpgradeNum(){
        return UpgradeNum;
    }
    public void Destroy()
    {
        if(closest!=null&&closest.TryGetComponent<Markchained>(out Markchained hinge)){
            closest.GetComponent<Markchained>().removemark();
            Debug.Log("remove");
        }
        Destroy(gameObject);

    }
    public void chained(){
        firstattack=false;
        lastchainNum-=1;
    }
    public int getchainNum(){
        return lastchainNum;
    }

}
