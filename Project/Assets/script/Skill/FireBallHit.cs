using UnityEngine;
using TMPro;
public class FireBallHit : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    [SerializeField]private GameObject anim;
    [SerializeField]private float animDestroySecond;
    [SerializeField]private TextMeshPro damageText;
    [SerializeField]float projectforce=10f;
    int lastpierceNum;
    int lastchainNum;
    [SerializeField]GameObject attackobject;
    Vector3 chainposition;
    void Start()
    {
        lastpierceNum=playerState.playerFireballpirece;
        lastchainNum=playerState.playerFireballchainNum;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(playerState.playerFireballdamage+basedamage);
            GameObject _anim=Instantiate(anim,this.transform.position, Quaternion.identity);
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text=""+(playerState.playerFireballdamage+basedamage);
            Destroy(_anim,animDestroySecond);
            if(lastpierceNum<=0){
                if(lastchainNum<=0){
                    Destroy(attackobject);
                }
                else{
                    chainposition=attackobject.GetComponent<FireBall>().getClosest(collider.gameObject);
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

