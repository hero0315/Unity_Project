using UnityEngine;

public class PassData : MonoBehaviour
{
    public string playerName;
    public int totalkill=0;
    public int totalcoin=0;
    public float totaltime=0;
    public int totalmoneyspend=0;
    public int HealthUpgrade=0;
    public float CooldownRecover=0;
    public int totalitemGet=0;
    public int totallevelTimes=0;
    public int totalDiedTimes=0;
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
    public void setdied(int n){
        totalDiedTimes+=n;
    }
    public void setlevelup(int n){
        totallevelTimes+=n;
    }
    public void setitem(int n){
        totalitemGet+=n;
    }
    public void setmoneyspend(int n){
        totalmoneyspend+=n;
    }
    public void setHealthUpgrade(int n){
        HealthUpgrade+=n;
    }
    public void setCoolDownRecover(float n){
        CooldownRecover+=n;
    }
    public void setUpgrade(int health,float cooldownRecover){
        setHealthUpgrade(health);
        setCoolDownRecover(cooldownRecover);
    }
}
