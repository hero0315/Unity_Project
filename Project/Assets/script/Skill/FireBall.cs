using UnityEngine;
using System.Collections.Generic;
public class FireBall : MonoBehaviour , Attack
{
    [SerializeField]private float Destroysecond;
    [SerializeField]int UpgradeNum=4;
    [SerializeField]float projectforce=10f;
    private List<GameObject> detect = new List<GameObject>();
    Transform closest;
    void Start()
    {
        Invoke("Destroy",Destroysecond);
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
        foreach (GameObject monster in detect){
            if(Vector3.Distance(monster.transform.position, collider.transform.position)==0){
                continue;
            }
            else if(Vector3.Distance(monster.transform.position, collider.transform.position)<distance){
                closest=monster.transform;
                distance=Vector3.Distance(monster.transform.position, collider.transform.position);
            }
        }
        if(closest==null){
            return Vector3.zero;
        }
        else{
            return closest.position;
        }
    }
    public void fly(){
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.right*projectforce,ForceMode2D.Impulse);
    }
    public void Upgrade1(){
        playerState.playerFireballdamage+=20;
    }
    public void Upgrade2(){
        playerState.playerFireballpirece+=1;
    }
    public void Upgrade3(){
        playerState.playerFireballFireNum+=1;
    }
    public void Upgrade4(){
        playerState.playerFireballchainNum+=1;
    }
    public int getUpgradeNum(){
        return UpgradeNum;
    }
    public string Upgrade1Descript(){
        return "FireBall Damage + 20";
    }
    public string Upgrade2Descript(){
        return "FireBall Pierce +1 Enemy";
    }
    public string Upgrade3Descript(){
        return "FireBall Fire +1 Project";
    }
    public string Upgrade4Descript(){
        return "FireBall Chain +1 Enemy";
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

