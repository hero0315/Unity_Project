using UnityEngine;
using System.Collections;
public class  WaterSplashDot : MonoBehaviour
{
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(WaterSplashDotDamage());
    }
    IEnumerator WaterSplashDotDamage(){
        while(true){
            float damage=watersplashState.WaterSplashDotdamage;
            this.gameObject.GetComponent<enemyController>().decreasehealth(damage);
            eventController.damageEvent.Invoke(damage,this.transform.position);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
