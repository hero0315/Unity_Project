using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class coin : MonoBehaviour
{
    [SerializeField]private GameObject Timer;
    [SerializeField]private TextMeshPro getcoinText;
    private bool isget=false;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="Player"&&isget==false){
            isget=true;
            TextMeshPro createText=Instantiate(getcoinText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text="+"+10+"$";
            playerState.coin+=10;
            Invoke("Destroysecond",0.8f);
            Timer.SetActive(true);
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.AddForce(this.transform.up*0.8f,ForceMode2D.Impulse);
        }
    }
    void Destroysecond(){
        Destroy(this.gameObject);
    }
}
