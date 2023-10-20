using TMPro;
using UnityEngine;

public class WaterSplashHit : MonoBehaviour
{
    [SerializeField]private TextMeshPro damageText;
    float timer=0;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(timer<=0.1f){
                float damage=watersplashState.WaterSplashdamage;
                eventController.damageEvent.Invoke(damage,this.transform.position);
            }
            else{
                WaterSplashDot waterSplashDot=collider.gameObject.AddComponent<WaterSplashDot>();
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(collider.gameObject.TryGetComponent<WaterSplashDot>(out WaterSplashDot waterSplashDot)){
                waterSplashDot.removeDot();
            }
        }
    }
    void Update(){
        timer+=Time.deltaTime;
    }
}
