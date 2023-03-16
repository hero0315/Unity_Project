using UnityEngine;
public class playerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public static Transform playpos;
    [SerializeField]private float maxHealth;
    [SerializeField]private float originmovespeed;
    [SerializeField]private float origincastspeed;
    [SerializeField]private float originfiredamage;
    void Awake(){
        setmovespeed(originmovespeed);
        setcastspeed(origincastspeed);
        setfiredamage(originfiredamage);
    }
    
    public float setmovespeed(float movespeed){
        float temp=playerState.playerMovespeed;
        playerState.playerMovespeed=movespeed;
        return temp;
    }
    public float setcastspeed(float castspeed){
        float temp=playerState.playerCastspeed;
        playerState.playerCastspeed=castspeed;
        return temp;
    }
    public float sethealth(float health){
        float temp=playerState.playerHealth;
        playerState.playerHealth=health;
        return temp;
    }
    public float setfiredamage(float firedamage){
        float temp=playerState.playerfiredamage;
        playerState.playerfiredamage=firedamage;
        return temp;
    }
    void Update(){
        playpos=player.transform;
    }
}
