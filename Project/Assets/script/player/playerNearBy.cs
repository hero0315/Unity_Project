using System.Collections.Generic;
using UnityEngine;

public class playerNearBy : MonoBehaviour
{
    GameObject closest;
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
    public GameObject getClosest(Vector3 mouspos){
        float distance=100; 
        closest=null;
        mosdistance=100;
        foreach (GameObject monster in detect){
            mosdistance=Vector3.Distance(monster.transform.position, mouspos);
            if(mosdistance<=mousemaxdistance){
                closest=monster;
                distance=mosdistance;
            }
        }
        return closest;
    }
}
