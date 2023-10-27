using UnityEngine;
using System.Collections.Generic;
public class BloodFloorHit : MonoBehaviour
{
    Dictionary<GameObject,BloodFloorDot> hitdic=new Dictionary<GameObject,BloodFloorDot>();
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            BloodFloorDot bloodFloorDot=collider.gameObject.AddComponent<BloodFloorDot>();
            hitdic.Add(collider.gameObject,bloodFloorDot);
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(hitdic.TryGetValue(collider.gameObject,out BloodFloorDot bloodFloorDot)){
                hitdic[collider.gameObject].removeDot();
                hitdic.Remove(collider.gameObject);
            }
        }
    }
    void Start(){
        Invoke("destory",BloodExplodeState.BloodExplodeFloorTime);
    }
    void destory(){
        foreach(GameObject obj in hitdic.Keys){
            if(obj.TryGetComponent<BloodFloorDot>(out BloodFloorDot bloodFloorDot)){
                hitdic[obj].removeDot();
            }
        }
        Destroy(this.gameObject);
    }
}
