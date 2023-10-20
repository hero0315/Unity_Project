using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class MagicWeapon : MonoBehaviour , Attack
{
    [SerializeField]private float basedamage;
    private List<GameObject> damagedlist= new List<GameObject>();
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="enemy"){
            if(!damagedlist.Contains(collider.gameObject)){
                float damage=magicweaponState.MagicWeaponDamage+basedamage;
                collider.gameObject.GetComponent<enemyController>().decreasehealth(damage);
                eventController.damageEvent.Invoke(damage,this.transform.position);
                damagedlist.Add(collider.gameObject);
                StartCoroutine(MagicWeaponDamageable());
                damagedlist.Remove(collider.gameObject);
            }
        }
    }
    IEnumerator MagicWeaponDamageable(){
            yield return new WaitForSeconds(0.3f);

    }

}
