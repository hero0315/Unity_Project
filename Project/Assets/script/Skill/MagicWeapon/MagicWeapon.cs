using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
public class MagicWeapon : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    [SerializeField]private TextMeshPro damageText;
    private List<GameObject> damagedlist= new List<GameObject>();
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(!damagedlist.Contains(collider.gameObject)){
            //if(!collider.gameObject.TryGetComponent<MarkHited>(out MarkHited component)){
                collider.gameObject.GetComponent<enemyController>().decreasehealth(magicweaponState.MagicWeaponDamage+basedamage);
                TextMeshPro createText = Instantiate(damageText,new Vector3(collider.transform.position.x,collider.transform.position.y+0.6f,collider.transform.position.z),Quaternion.identity);
                createText.text=""+(magicweaponState.MagicWeaponDamage+basedamage);
                damagedlist.Add(collider.gameObject);
                StartCoroutine(MagicWeaponDamageable());
                damagedlist.Remove(collider.gameObject);
                //collider.gameObject.AddComponent<MarkHited>();
            }
        }
    }
    IEnumerator MagicWeaponDamageable(){
            yield return new WaitForSeconds(0.3f);

    }

}
