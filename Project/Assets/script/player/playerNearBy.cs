using System.Collections.Generic;
using UnityEngine;

public class playerNearBy : MonoBehaviour
{
    private List<GameObject> detect = new List<GameObject>();
    void Start(){

    }
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
    public GameObject getClosest(){
        float distance=100; 
        GameObject closest=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance<distance){
                closest=monster;
                distance=mosterdistance;
            }
        }
        if(detect.Count==0){
            return null;
        }
        else{
            return closest;
        }
    }
    public GameObject getClosest(float radio){
        float distance=100; 
        GameObject closest=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance<distance&&distance<radio){
                closest=monster;
                distance=mosterdistance;
            }
        }
        if(detect.Count==0){
            return null;
        }
        else{
            return closest;
        }
    }
}
