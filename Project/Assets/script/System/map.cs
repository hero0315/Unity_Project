using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    [SerializeField]private Transform playerpos;
    [SerializeField]private GameObject mapperfab;
    [SerializeField]private Transform father;
    [SerializeField]private Vector2 currpos;
    [SerializeField]Dictionary<Vector2, GameObject> maplist=new Dictionary<Vector2, GameObject>();
    [SerializeField]private Vector2 pos;
    void Start(){
        for(int i = -1;i<=1;i++){
            for(int j = -1;j<=1;j++){
                GameObject _map = Instantiate(mapperfab,new Vector3(i*25f,j*25f,0f),Quaternion.Euler(0f,0f,0f),father);
                maplist.Add(new Vector2(i,j),_map);
            }
        }
    }
    void Update(){
        //if((playerpos.position.x-10f)%25f<=0.5f||(playerpos.position.y-15f)%25f<=0.5f){ //效能不知加不加比較好
            currpos=new Vector2(Mathf.Ceil((playerpos.position.x-10f)/25f),Mathf.Ceil((playerpos.position.y-15f)/25f));
            if(currpos!=pos){
                pos=currpos;
                List <Vector2> temp = new List<Vector2>();
                foreach(Vector2 _pos in maplist.Keys){
                    if(currpos.x+2==_pos.x||currpos.x-2==_pos.x){
                        Destroy(maplist[_pos].gameObject);
                        temp.Add(_pos);
                    }
                    else if(currpos.y+2==_pos.y||currpos.y-2==_pos.y){
                        Destroy(maplist[_pos].gameObject);
                        temp.Add(_pos);
                    }
                }
                foreach(Vector2 tempos in temp){
                    maplist.Remove(tempos);
                }
                foreach(Vector2 _test in maplist.Keys){
                }
                for(int i = -1;i<=1;i++){
                    for(int j = -1;j<=1;j++){
                        Vector2 _temp = new Vector2(currpos.x+i,currpos.y+j);
                        if(!maplist.ContainsKey(_temp)){
                            GameObject _map = Instantiate(mapperfab,new Vector3((currpos.x+i)*25f,(currpos.y+j)*25f,0f),Quaternion.Euler(0f,0f,0f),father);
                            maplist.Add(_temp,_map);
                        }
                    }
                }
            }
        //}
    }
}