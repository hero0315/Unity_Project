using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlagueSlashHit : MonoBehaviour
{
    [SerializeField]private TextMeshPro damageText;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="enemy"){
            collider.gameObject.GetComponent<enemyController>().decreasehealth(plagueslashState.PlagueSlashDamage);
            TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
            createText.text=""+(plagueslashState.PlagueSlashDamage);
        }
    }
}
