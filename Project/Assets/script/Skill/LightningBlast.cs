using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class LightningBlast : MonoBehaviour , Attack
{
    [SerializeField]int UpgradeNum=4;
    private List<GameObject> detect = new List<GameObject>();
    GameObject closest;
    public int lastchainNum;
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;
    [SerializeField]Transform chainpoint;
    private GameObject target;
    void Start()
    {
        Invoke("Destroy",0.3f); 
        Invoke("Hitenemy",0.04f); 
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Add(collider.gameObject);
            Debug.Log(detect.Count);
        }
    }
    void getClosest(Vector3 enemypos){
        Debug.Log(detect.Count);
        float distance=100; 
        closest=null;
        foreach (GameObject monster in detect){
            Debug.Log("牙");
            if(monster.transform.position==enemypos){
                continue;
            }
            else if(Vector3.Distance(monster.transform.position, enemypos)<=distance&&!monster.TryGetComponent<Markchained>(out Markchained hinge)){
                closest=monster;
                distance=Vector3.Distance(monster.transform.position, enemypos);
            }
            
        }
    }
    private void Hitenemy(){
            if(target!=null){
                if(lastchainNum>0){
                    getClosest(target.transform.position);
                    if(closest!=null){
                        target.AddComponent<Markchained>();
                        Vector3 dir= closest.transform.position-chainpoint.position;
                        GameObject createAttack= Instantiate(this.gameObject,(closest.transform.position-chainpoint.position)/2+chainpoint.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                        createAttack.GetComponent<LightningBlast>().initialization(Vector3.Distance(closest.transform.position,chainpoint.position));           
                    }
            }
                target.GetComponent<enemyController>().decreasehealth(playerState.playerLightningBlastdamage+basedamage);
                TextMeshPro createText = Instantiate(damageText,new Vector3(target.transform.position.x,target.transform.position.y+0.6f,target.transform.position.z),Quaternion.identity);
                createText.text=""+(playerState.playerLightningBlastdamage+basedamage);
                Invoke("removechainmark",0.05f); 
        }     
    }
    public void initialization(float _distance){
        lastchainNum-=1;
        transform.localScale=new Vector3(_distance*2/10,0.25f,0.25f);
        this.GetComponent<CircleCollider2D>().radius=6;
        setTarget(closest);

    }
    public void setTarget(GameObject setobject){
        target=setobject;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
void removechainmark(){
        if(target.TryGetComponent<Markchained>(out Markchained hinge)){
            target.GetComponent<Markchained>().removemark();
        }
    }
    public void Upgrade1(){
        playerState.playerLightningBlastdamage+=15;
    }
    public void Upgrade2(){
        playerState.playerLightningBlastchainNum+=1;
    }
    public string Upgrade1Descript(){
        return "Lightning Blast Damage + 20";
    }
    public string Upgrade2Descript(){
        return "Lightning Blast Chain +1 Enemy";
    }
    public int getUpgradeNum(){
        return UpgradeNum;
    }
}
