using UnityEngine;

public class BloodFloorHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            BloodFloorDot bloodFloorDot=collider.gameObject.AddComponent<BloodFloorDot>();
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(collider.gameObject.TryGetComponent<BloodFloorDot>(out BloodFloorDot bloodFloorDot)){
                bloodFloorDot.removeDot();
            }
        }
    }
    void Start(){
        Destroy(this.gameObject,BloodExplodeState.BloodExplodeFloorTime);
    }
}
