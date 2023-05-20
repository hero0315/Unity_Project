using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class LightningBlast : MonoBehaviour , Attack
{
    private List<GameObject> detect = new List<GameObject>();
    GameObject closest;
    private int lastchainNum;
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;
    [SerializeField]Transform chainpoint;
    private GameObject target;
    [SerializeField]int ischained=0;
    private float distance=100; 
    void Start()
    {
        Invoke("Destroy",0.3f); 
        Invoke("Hitenemy",0.04f); 
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Add(collider.gameObject);
        }
    }
    void getClosest(Vector3 chainpos){ 
        closest=null;
        foreach (GameObject monster in detect){
            float temp=Vector3.Distance(monster.transform.position, chainpos);
            if(temp<=0.3){
                continue;
            }
            else if(Vector3.Distance(monster.transform.position, chainpos)<=distance&&!monster.TryGetComponent<Markchained>(out Markchained hinge)){
                closest=monster;
                distance=Vector3.Distance(monster.transform.position, chainpos);
            }
        }
    }
    private void Hitenemy(){
        if(target!=null){
            target.GetComponent<enemyController>().decreasehealth(playerState.playerLightningBlastdamage+basedamage);
            TextMeshPro createText = Instantiate(damageText,new Vector3(target.transform.position.x,target.transform.position.y+0.6f,target.transform.position.z),Quaternion.identity);
            createText.text=""+(playerState.playerLightningBlastdamage+basedamage);
            if(ischained<playerState.playerLightningBlastchainNum){
                getClosest(chainpoint.transform.position);
                if(closest!=null){
                    target.AddComponent<Markchained>();
                    Vector3 dir= closest.transform.position-chainpoint.position;
                    GameObject createAttack= Instantiate(this.gameObject,(closest.transform.position-chainpoint.position)/2+chainpoint.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                    createAttack.GetComponent<LightningBlast>().initialization(distance,closest,ischained);           
                    Invoke("removechainmark",0.1f);
                }
            }
        }     
    }
    public void initialization(float _distance,GameObject _closest,int _ischained){
        transform.localScale=new Vector3(_distance*2/10,0.25f,0.25f);
        this.GetComponent<CircleCollider2D>().radius=4.5f;
        setTarget(_closest);
        setischainNum(_ischained);
    }
    public void setTarget(GameObject setobject){
        target=setobject;
    }
    void setischainNum(int _ischained){
        ischained=_ischained+1;
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
}
