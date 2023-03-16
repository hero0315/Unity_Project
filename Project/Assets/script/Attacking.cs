using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField]private GameObject firepoint;
    private Vector2 mousepos;
    [SerializeField]private Camera cam;
    [System.Serializable]
    public class attackpool{
        public GameObject attack;
        public float projectforce=3f;
        public float spellcastspeed=1;
        public float fixangle=0;
        public string buttonName;
        public float cooldown;
    }
    public List<attackpool> attackpools;
    void Update()
    {
            foreach(attackpool pool in attackpools){
                if(Input.GetButton(pool.buttonName)&&pool.cooldown<=0){
                    mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
                    Fireproject(pool);
                    pool.cooldown=playerState.playerCastspeed*pool.spellcastspeed;
                }
                else if(pool.cooldown>=0){
                    pool.cooldown-=Time.deltaTime;
                }
        }
    }
    void Fireproject(attackpool attack){
        Vector2 dir = mousepos-(Vector2)firepoint.transform.position;
        firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        GameObject projectile = Instantiate(attack.attack,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f+90f+attack.fixangle));
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.up*attack.projectforce,ForceMode2D.Impulse);
    }
}
