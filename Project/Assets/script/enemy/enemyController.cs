using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField]private float originhealth;
    [SerializeField]private float damage;
    [SerializeField]private float attackcooldown;
    [SerializeField]private float cooldown=0;
    [SerializeField]private float killexp=0;
    private float monsterhealth;
    void Start(){
        monsterhealth=originhealth;
    }
    void Update(){
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            if(cooldown<=0){
                playerState.playerHealth-=(damage*playerState.playerDefence);
                cooldown=attackcooldown;
            }
        }
    }
    public void decreasehealth(float damage){
        monsterhealth-=damage;
        if(monsterhealth<=0){
            monsterhealth=originhealth;
            playerState.exp+=killexp;
            gameObject.SetActive(false);
        }
    }
}
