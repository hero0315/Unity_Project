using System.Collections.Generic;
using UnityEngine;

public class playerNearBy : MonoBehaviour
{
    Vector3 closest;
    private List<GameObject> detect = new List<GameObject>();
    [SerializeField]private int mousemaxdistance;
    private float mosdistance;
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
    public Vector3 getClosest(Vector3 mouspos){
        float distance=100; 
        closest=Vector3.zero;
        foreach (GameObject monster in detect){
            mosdistance=Vector3.Distance(monster.transform.position, mouspos);
            if(mosdistance<=mousemaxdistance){
                closest=monster.transform.position;
                distance=mosdistance;
            }
        }
        if(closest==Vector3.zero){
            return Vector3.zero;
        }
        else{
            return closest;
        }
    }
}
