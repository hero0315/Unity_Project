using UnityEngine;
using TMPro;
using System.Collections;
public class FlameJetDot : MonoBehaviour
{
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(FlameJetDotDamage());
    }
    IEnumerator FlameJetDotDamage(){
        while(true){
            float damage=FlameJetState.FlameJetDamage;
            this.gameObject.GetComponent<enemyController>().decreasehealth(damage);
            eventController.damageEvent.Invoke(damage,this.transform.position);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
