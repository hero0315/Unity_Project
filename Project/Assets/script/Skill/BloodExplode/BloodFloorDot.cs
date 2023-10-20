using System.Collections;
using UnityEngine;

public class BloodFloorDot : MonoBehaviour
{
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(BloodFloorDotDamage());
    }
    IEnumerator BloodFloorDotDamage(){
        while(true){
            float damage=BloodExplodeState.BloodExplodeFloorDamage;
            this.gameObject.GetComponent<enemyController>().decreasehealth(damage);
            eventController.damageEvent.Invoke(damage,this.transform.position);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
