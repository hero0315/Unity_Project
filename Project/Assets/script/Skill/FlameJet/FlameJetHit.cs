using TMPro;
using UnityEngine;

public class FlameJetHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            FlameJetDot flameJetDot=collider.gameObject.AddComponent<FlameJetDot>();
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
