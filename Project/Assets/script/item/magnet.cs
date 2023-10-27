using UnityEngine;

public class magnet : MonoBehaviour
{
    [SerializeField]private GameObject Magnet;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="Player"){
            eventController.eatMagnetEvent.Invoke();
            Destroy(Magnet);
        }
    }
}
