using UnityEngine;
using TMPro;
public class FireBall : MonoBehaviour , Attack
{
    [SerializeField]private float Destroysecond;
    [SerializeField]private float basedamage;
    [SerializeField]private GameObject anim;
    [SerializeField]private float animDestroySecond;
    [SerializeField]private TextMeshPro damageText;

    void Start()
    {
        Invoke("Destroy",Destroysecond);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(basedamage*playerState.playerfiredamage);
            GameObject _anim=Instantiate(anim,this.transform.position, Quaternion.identity);
            TextMeshPro createText = Instantiate(damageText,new Vector3(transform.position.x,transform.position.y+0.6f,transform.position.z),Quaternion.identity);
            createText.text=""+basedamage;
            Destroy(_anim,animDestroySecond);
            Destroy(gameObject);
        }
        
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
