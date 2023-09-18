using UnityEngine;
public class enemyController : MonoBehaviour
{
    [SerializeField]private float originhealth;
    [SerializeField]private float damage;
    [SerializeField]private float attackcooldown;
    [SerializeField]private float killexp=0;
    [SerializeField]private GameObject coin;
    public float monsterhealth;
    private bool damageable=true;
    void Start(){
        monsterhealth=originhealth;
    }
    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            if(damageable==true){
                damageable=false;
                playerState.playerHealth-=(damage*playerState.playerDefence);
                UITextController.hpEvent.Invoke();
                Invoke("setdamageable",attackcooldown);
            }
        }
    }
    public void decreasehealth(float damage){
        monsterhealth-=damage;
        if(monsterhealth<=0){
            if(BloodExplodeState.BloodExplodeEnable==true){
                BloodExplodeAttacker.monsterdead.Invoke(this.transform.position);
            }
            monsterhealth=originhealth;
            playerState.exp+=killexp;
            UITextController.expEvent.Invoke();
            GameObject _coin = Instantiate(coin);
            _coin.transform.position=this.transform.position;
            gameObject.SetActive(false);
            
        }
    }
    private void setdamageable(){
        damageable=true;
    }
}
