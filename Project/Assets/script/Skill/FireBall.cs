using UnityEngine;
using System.Collections.Generic;
public class FireBall : MonoBehaviour , Attack
{
    [SerializeField]private float Destroysecond;
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
    public Vector3 getClosest(Vector3 chainpos){
        float distance=100; 
        closest=null;
        foreach (GameObject monster in detect){
            float temp=Vector3.Distance(monster.transform.position, chainpos);
            if(temp<0.3){
                continue;
            }
            else if(temp<distance){
                closest=monster.transform;
                distance=temp;
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
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

