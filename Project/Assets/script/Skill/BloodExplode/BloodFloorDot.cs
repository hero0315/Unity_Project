using System.Collections;
using TMPro;
using UnityEngine;

public class BloodFloorDot : MonoBehaviour
{
    private TextMeshPro damagetext;
    public void setTextMeshPro(TextMeshPro damageText){
        damagetext=damageText;
    }
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(BloodFloorDotDamage());
    }
    IEnumerator BloodFloorDotDamage(){
        while(true){
            this.gameObject.GetComponent<enemyController>().decreasehealth(BloodExplodeState.BloodExplodeFloorDamage);
            TextMeshPro createText = Instantiate(damagetext,new Vector3(this.transform.position.x,this.transform.position.y+0.6f,this.transform.position.z),Quaternion.identity);
            createText.text=""+(BloodExplodeState.BloodExplodeFloorDamage);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
