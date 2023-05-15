using UnityEngine;
using TMPro;
public class LightningBlast : MonoBehaviour , Attack
{
    [SerializeField]private float Destroysecond;
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;

    void Start()
    {
        Destroy(this.gameObject,3f);
        Invoke("NoDamageCount",0.1f);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(basedamage+playerState.playerLightningBlastdamage);
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text=""+basedamage;
        }
    }
    void NoDamageCount()
    {
        BoxCollider2D Cd = this.GetComponent<BoxCollider2D>();
        Cd.enabled=false;
    }
}
