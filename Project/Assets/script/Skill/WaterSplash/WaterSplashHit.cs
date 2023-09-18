using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashHit : MonoBehaviour
{
    [SerializeField]private TextMeshPro damageText;
    float timer=0;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(timer<=0.1f){
                TextMeshPro createText = Instantiate(damageText,new Vector3(this.transform.position.x,this.transform.position.y+0.6f,this.transform.position.z),Quaternion.identity);
                createText.text=""+(watersplashState.WaterSplashdamage);
            }
            else{
                WaterSplashDot waterSplashDot=collider.gameObject.AddComponent<WaterSplashDot>();
                waterSplashDot.setTextMeshPro(damageText);
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
