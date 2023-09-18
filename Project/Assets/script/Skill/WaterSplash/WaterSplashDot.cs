using UnityEngine;
using TMPro;
using System.Collections;
public class  WaterSplashDot : MonoBehaviour
{
    private TextMeshPro damagetext;
    public void setTextMeshPro(TextMeshPro damageText){
        damagetext=damageText;
    }
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(WaterSplashDotDamage());
    }
    IEnumerator WaterSplashDotDamage(){
        while(true){
            this.gameObject.GetComponent<enemyController>().decreasehealth(watersplashState.WaterSplashDotdamage);
            TextMeshPro createText = Instantiate(damagetext,new Vector3(this.transform.position.x,this.transform.position.y+0.6f,this.transform.position.z),Quaternion.identity);
            createText.text=""+(watersplashState.WaterSplashDotdamage);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
