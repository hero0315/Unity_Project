using UnityEngine;
using System.Collections;
public class coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="Player"){
            eventController.eatcoinEvent.Invoke(this.transform.position);
            Destroy(this.gameObject);
        }
    }
    public void startfly(){
        StartCoroutine(Coinfly());
    }
    IEnumerator Coinfly(){
        while(true){
            Vector3 lerp = Vector3.Lerp(transform.position,playerController.playpos.position,Time.deltaTime*10);
            this.transform.position=lerp;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
