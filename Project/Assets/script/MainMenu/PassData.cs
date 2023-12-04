using UnityEngine;

public class PassData : MonoBehaviour
{
    public string playerName;
    public int totalkill=0;
    public int totalcoin=0;
    public float totaltime=0;
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void setName(string name){
        playerName=name;
    }
    public void settime(float time){
        totaltime+=time;
    }
    public void setcoin(int coin){
        totalcoin+=coin;
    }
    public void setkill(int kill){
        totalkill+=kill;
    }
}
