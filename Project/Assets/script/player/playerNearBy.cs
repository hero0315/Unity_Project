using System.Collections.Generic;
using UnityEngine;

public class playerNearBy : MonoBehaviour
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
    public GameObject getClosest(float radio){
        float distance=100; 
        GameObject closest=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance<distance&&mosterdistance<radio){
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
    public GameObject getFarthest(float radio){
        float distance=0; 
        GameObject farthest=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance>distance&&mosterdistance<radio){
                farthest=monster;
                distance=mosterdistance;
            }
        }
        if(detect.Count==0){
            return null;
        }
        else{
            return farthest;
        }
    }
    public GameObject getRandom(float radio){
        if(detect.Count==0){
            return null;
        }
        List<GameObject> monsterlist=new List<GameObject>();
        foreach(GameObject monster in detect){
            if(Vector3.Distance(monster.transform.position, this.transform.position)<radio){
                monsterlist.Add(monster);
            }
        }
        if(monsterlist.Count==0){
            return null;
        }
        else{
            return monsterlist[Random.Range(0,monsterlist.Count)];
        }
    }
}
