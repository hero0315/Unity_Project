using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField]private float originhealth;
    [SerializeField]private float damage;
    [SerializeField]private float attackcooldown;
    [SerializeField]private float killexp=0;
    private float monsterhealth;
    private bool damageable=true;
    void Start(){
        monsterhealth=originhealth;
    }
    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            if(damageable==true){
                damageable=false;
                playerState.playerHealth-=(damage*playerState.playerDefence);
                Invoke("setdamageable",attackcooldown);
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
    private void setdamageable(){
        damageable=true;
    }
}
