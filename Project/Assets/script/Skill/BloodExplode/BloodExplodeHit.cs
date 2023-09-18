using TMPro;
using UnityEngine;

public class BloodExplodeHit : MonoBehaviour
{
    [SerializeField]private TextMeshPro damageText;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text=""+(BloodExplodeState.BloodExplodeDamage);
        }
    }
    void Start(){
        Destroy(this.gameObject,0.5f);
    }
}
