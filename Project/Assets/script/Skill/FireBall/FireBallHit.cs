using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class FireBallHit : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    [SerializeField]private GameObject anim;
    [SerializeField]private float animDestroySecond;
    [SerializeField]float projectforce=10f;
    [SerializeField]int lastpierceNum;
    [SerializeField]int lastchainNum;
    [SerializeField]GameObject attackobject;
    Vector3 chainposition;
    List<GameObject> hitlist=new List<GameObject>();
    void Start()
    {
        lastpierceNum=fireballState.Fireballpierce;
        lastchainNum=fireballState.FireballchainNum;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(!hitlist.Contains(collider.gameObject)){
                hitlist.Add(collider.gameObject);
                float damage=fireballState.Fireballdamage+basedamage;
                eventController.damageEvent.Invoke(damage,collider.transform.position);
                collider.gameObject.GetComponent<enemyController>().decreasehealth(damage);
                GameObject _anim=Instantiate(anim,this.transform.position, Quaternion.identity);
                Destroy(_anim,animDestroySecond);
            }
            if(lastpierceNum<=0){
                if(lastchainNum<=0){
                    Destroy(attackobject);
                }
                else{
                    chainposition=attackobject.GetComponent<FireBall>().getClosest(collider.gameObject.transform.position,hitlist);
                    if(chainposition!=Vector3.zero){
                        Rigidbody2D rb = attackobject.GetComponent<Rigidbody2D>();
                        rb.velocity=Vector3.zero;
                        attackobject.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(chainposition.y-attackobject.transform.position.y,chainposition.x-attackobject.transform.position.x)* Mathf.Rad2Deg);
                        rb.AddForce(attackobject.transform.right*projectforce,ForceMode2D.Impulse);
                        lastchainNum-=1;
                    }
                    else{
                        Destroy(attackobject);
                    }
                }
            }
            else{
                lastpierceNum-=1;
            }
        }
    }
}

