using UnityEngine;

public class BloodExplodeHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            float damage=BloodExplodeState.BloodExplodeDamage;
            collider.gameObject.GetComponent<enemyController>().decreasehealth(damage);
            eventController.damageEvent.Invoke(damage,collider.transform.position);
        }
    }
    void Start(){
        Destroy(this.gameObject,0.4f);
    }
}
