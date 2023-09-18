using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueSlashAttacker : MonoBehaviour
{
    [SerializeField] SkillController skillController;
    [SerializeField]GameObject Plagueslash;
    [SerializeField]playerNearBy playernearBy;
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
        else if(plagueslashState.PlagueSlashEnable&&!plagueslashState.PlagueSlashiscooldowning){
            GameObject Closest = playernearBy.getClosest(1.5f);
            if(Closest!=null){
                Attack(Closest);
                plagueslashState.PlagueSlashiscooldowning=true;
                skillController.skillImagepool[PlagueSlashnum].fillAmount=0;
            }
        }
    }
    void Attack(GameObject Closest){
        Plagueslash.SetActive(true);
        attackpos(Closest);
        Invoke("finishAttack",0.42f);
    }
    void attackpos(GameObject Closest){
        float angle; 
        dir = Closest.transform.position-this.transform.position;
        angle=Mathf.Atan2(dir.y,dir.x);
        this.transform.rotation=Quaternion.Euler(0f,0f,angle* Mathf.Rad2Deg-90f);
    }
    void finishAttack(){
        Plagueslash.SetActive(false);
    }
    public void setPlagueSlashnum(int num){
        PlagueSlashnum=num;
    }
}
