using UnityEngine;
public class playerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public static Transform playpos;
    [SerializeField]private float maxHealth;
    [SerializeField]private float originmovespeed;
    [SerializeField]private float origincastspeed;
    void Awake(){
        PassData passdata = GameObject.Find("PassData").GetComponent<PassData>();
        setmovespeed(originmovespeed);
        setCoolDownRecover(1*(1+(passdata.CooldownRecover/100)));
        sethealth(100+passdata.HealthUpgrade*10);
    }
    
    public float setmovespeed(float movespeed){
        float temp=playerState.playerMovespeed;
        playerState.playerMovespeed=movespeed;
        return temp;
    }
    public float setCoolDownRecover(float castspeed){
        float temp=playerState.playerCoolDownRecover;
        playerState.playerCoolDownRecover=castspeed;
        return temp;
    }
    public float sethealth(float health){
        float temp=playerState.playerHealth;
        playerState.playerHealth=health;
        return temp;
    }
    void Update(){
        playpos=player.transform;
    }
}
