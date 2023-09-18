using TMPro;
using UnityEngine;

public class FlameJetHit : MonoBehaviour
{
    [SerializeField]private TextMeshPro damageText;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            FlameJetDot flameJetDot=collider.gameObject.AddComponent<FlameJetDot>();
            flameJetDot.setTextMeshPro(damageText);
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(collider.gameObject.TryGetComponent<FlameJetDot>(out FlameJetDot flameJetDot)){
                flameJetDot.removeDot();
            }
        }
    }
}
