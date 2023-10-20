using UnityEngine;

public class BloodExplodeHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            float damage=BloodExplodeState.BloodExplodeDamage;
            eventController.damageEvent.Invoke(damage,this.transform.position);
        }
    }
    void Start(){
        Destroy(this.gameObject,0.4f);
    }
}
