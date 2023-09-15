using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBlastDetect : MonoBehaviour
{
    private List<GameObject> detect = new List<GameObject>();
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Add(collider.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.tag=="enemy"){
            detect.Remove(collider.gameObject);
        }
    }
    public bool anyNearby(){
        if(detect.Count==0){
            return false;
        }
        else{
            return true;
        }
        
    }
    public GameObject getFar(){
        float distance=0; 
        GameObject far=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance>distance){
                far=monster;
                distance=mosterdistance;
            }
        }
        if(detect.Count==0){
            return null;
        }
        else{
            return far;
        }
    }
}
