using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueSlashDetect : MonoBehaviour
{
    [SerializeField]PlagueSlashAttacker PlagueSlashattacker;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            PlagueSlashattacker.Addlist(collider.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.tag=="enemy"){
            PlagueSlashattacker.Removelist(collider.gameObject);
        }
    }
}
