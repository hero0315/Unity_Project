using UnityEngine;
public class PlagueSlashHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            float damage=plagueslashState.PlagueSlashDamage;
            collider.gameObject.GetComponent<enemyController>().decreasehealth(damage);
            eventController.damageEvent.Invoke(damage,collider.transform.position);
        }
    }
}
