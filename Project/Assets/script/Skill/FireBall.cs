using UnityEngine;
using TMPro;
public class FireBall : MonoBehaviour , Attack
{
    [SerializeField]private float Destroysecond;
    [SerializeField]private float basedamage;
    private float extarDamage;
    [SerializeField]private GameObject anim;
    [SerializeField]private float animDestroySecond;
    [SerializeField]private TextMeshPro damageText;

    void Start()
    {
        Invoke("Destroy",Destroysecond);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(playerState.playerFireballdamage+basedamage);
            GameObject _anim=Instantiate(anim,this.transform.position, Quaternion.identity);
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text=""+(playerState.playerFireballdamage+basedamage);
            Destroy(_anim,animDestroySecond);
            Destroy(gameObject);
        }
        
    }
    public void Upgrade1(){
        playerState.playerFireballdamage+=20;
    }
    public string Upgrade1Descript(){
        return "FireBall Damage + 20";
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
