using UnityEngine;
using TMPro;
public class LightningBlastHit : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;
    public int lastchainNum;
    [SerializeField]GameObject attackobject;
    Vector3 chainposition;
    [SerializeField]Transform chainpoint;
    private bool ischained=false;
    void Start()
    {
        lastchainNum=attackobject.GetComponent<LightningBlast>().getchainNum();
        Invoke("NoDamageCount",0.1f);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"&&!collider.TryGetComponent<MarkHited>(out MarkHited hinge)){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(playerState.playerFireballdamage+basedamage);
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            collider.gameObject.AddComponent<MarkHited>();
            createText.text=""+(playerState.playerFireballdamage+basedamage);
            if(lastchainNum>=0&&ischained==false){
                chainposition=attackobject.GetComponent<LightningBlast>().getClosest(collider.gameObject);
                    if(chainposition!=Vector3.zero){
                        Rigidbody2D rb = attackobject.GetComponent<Rigidbody2D>();
                        rb.velocity=Vector3.zero;
                        Vector3 dir= chainposition-chainpoint.position;
                        float distance=Vector3.Distance(chainposition,chainpoint.position);
                        GameObject createAttack= Instantiate(attackobject,(chainposition-chainpoint.position)/2+chainpoint.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
                        createAttack.GetComponent<LightningBlast>().chained();
                        createAttack.transform.localScale=new Vector3(distance*2/10,0.25f,0.25f);
                        createAttack.GetComponent<CircleCollider2D>().radius=8;                     
                    }
            }
            collider.gameObject.GetComponent<MarkHited>().removemark();
        }
    }
    private void chained(){
        ischained=true;
    }
    void NoDamageCount()
    {
        BoxCollider2D Cd = this.GetComponent<BoxCollider2D>();
        Cd.enabled=false;
    }
}

