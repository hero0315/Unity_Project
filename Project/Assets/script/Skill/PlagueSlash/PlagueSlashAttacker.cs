using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueSlashAttacker : MonoBehaviour
{
    [SerializeField] SkillController skillController;
    [SerializeField]GameObject Plagueslash;
    public List<GameObject> detect = new List<GameObject>();
    int PlagueSlashnum;
    private Vector3 dir;
    void Update()
    {
        if(plagueslashState.PlagueSlashEnable&&plagueslashState.PlagueSlashiscooldowning){
            skillController.skillImagepool[PlagueSlashnum].fillAmount+= (1/ plagueslashState.PlagueSlashcooldown*Time.deltaTime);
            if(skillController.skillImagepool[PlagueSlashnum].fillAmount>=1){
                plagueslashState.PlagueSlashiscooldowning=false;
            }
        }
        else if(plagueslashState.PlagueSlashEnable&&detect.Count!=0&&!plagueslashState.PlagueSlashiscooldowning){
            Attack();
            plagueslashState.PlagueSlashiscooldowning=true;
            skillController.skillImagepool[PlagueSlashnum].fillAmount=0;
        }
    }
    void Attack(){
        Plagueslash.SetActive(true);
        attackpos();
        Invoke("finishAttack",0.42f);
    }
    public GameObject getClosest(){
        float distance=100; 
        GameObject closest=null;
        foreach (GameObject monster in detect){
            float mosterdistance=Vector3.Distance(monster.transform.position, this.transform.position);
            if(mosterdistance<distance){
                closest=monster;
                distance=mosterdistance;
            }
        }
        return closest;
    }
    void attackpos(){
        float angle;
        dir = getClosest().transform.position-this.transform.position;
        angle=Mathf.Atan2(dir.y,dir.x);
        this.transform.rotation=Quaternion.Euler(0f,0f,angle* Mathf.Rad2Deg-90f);
    }
    void finishAttack(){
        Plagueslash.SetActive(false);
    }
    public void Addlist(GameObject monster){
        detect.Add(monster);
    }
    public void Removelist(GameObject monster){
        detect.Remove(monster);
    }
    public void setPlagueSlashnum(int num){
        PlagueSlashnum=num;
    }
}
