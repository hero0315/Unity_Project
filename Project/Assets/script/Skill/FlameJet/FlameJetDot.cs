using UnityEngine;
using TMPro;
using System.Collections;
public class FlameJetDot : MonoBehaviour
{
    private TextMeshPro damagetext;
    public void setTextMeshPro(TextMeshPro damageText){
        damagetext=damageText;
    }
    public void removeDot(){
        Destroy(this);
    }
    void Start(){
        StartCoroutine(FlameJetDotDamage());
    }
    IEnumerator FlameJetDotDamage(){
        while(true){
            this.gameObject.GetComponent<enemyController>().decreasehealth(FlameJetState.FlameJetDamage);
            TextMeshPro createText = Instantiate(damagetext,new Vector3(this.transform.position.x,this.transform.position.y+0.6f,this.transform.position.z),Quaternion.identity);
            createText.text=""+(FlameJetState.FlameJetDamage);
            Debug.Log(gameObject.GetComponent<enemyController>().monsterhealth);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
