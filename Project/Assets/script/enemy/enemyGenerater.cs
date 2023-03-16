using System.Collections.Generic;
using UnityEngine;

public class enemyGenerater : MonoBehaviour
{
    [SerializeField]private GameObject monster;
    [SerializeField]private Transform playerpos;
    [System.Serializable]
    public class spawnpool{
        public float Timer=0;
        public string type;
        public GameObject monster;
        public float spawndelay;
        public int size;
    }
    public List<spawnpool> spawnpools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    void Start(){
        poolDictionary=new Dictionary<string, Queue<GameObject>>();
        foreach(spawnpool spawnpool in spawnpools){
            Queue<GameObject> objpool=new Queue<GameObject>();
            for(int i=0;i<spawnpool.size;i++){
                GameObject obj = Instantiate(spawnpool.monster);
                obj.SetActive(false);
                objpool.Enqueue(obj);
            }
            poolDictionary.Add(spawnpool.type,objpool);
        }
    }
    void Update(){
        foreach(spawnpool spawnpool in spawnpools){
            if(spawnpool.Timer<=0){
                spawnfrompool(spawnpool.type);
                spawnpool.Timer=spawnpool.spawndelay;
            }
            else{
                spawnpool.Timer-=Time.deltaTime;
            }
        }
    }
    void spawnfrompool(string type){
        GameObject objectTospawn=poolDictionary[type].Dequeue();
        objectTospawn.SetActive(true);
        int random=Random.Range(1,5);
        if(random==1){
            objectTospawn.transform.position=new Vector2(playerpos.position.x-Random.Range(11,17),Random.Range(-5,6)+playerpos.position.y);
        }
        else if(random==2){
            objectTospawn.transform.position=new Vector2(playerpos.position.x+Random.Range(11,17),Random.Range(-5,6)+playerpos.position.y);
        }
        else if(random==3){
            objectTospawn.transform.position=new Vector2(Random.Range(-9,10)+playerpos.position.x,playerpos.position.y-Random.Range(7,13));
        }
        else if(random==4){
            objectTospawn.transform.position=new Vector2(Random.Range(-9,10)+playerpos.position.x,playerpos.position.y+Random.Range(7,13));
        }
        poolDictionary[type].Enqueue(objectTospawn);
    }
}
