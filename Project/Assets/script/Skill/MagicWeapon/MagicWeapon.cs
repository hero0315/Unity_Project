using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class MagicWeapon : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(!collider.gameObject.TryGetComponent<MarkHited>(out MarkHited component)){
                collider.gameObject.GetComponent<enemyController>().decreasehealth(magicweaponState.MagicWeaponDamage+basedamage);
                TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
                createText.text=""+(magicweaponState.MagicWeaponDamage+basedamage);
                collider.gameObject.AddComponent<MarkHited>();
            }
        }
    }

}
