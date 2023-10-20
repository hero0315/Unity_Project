using UnityEngine;

public class FireBallAttacker : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private Transform firepoint;
    [SerializeField] SkillController skillController;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject fireball;
    private int FireballNum;
    public void setFireballNum(int num){
       FireballNum=num;
    }
    void Update()
    {
        if(fireballState.FireballEnable&&fireballState.Fireballcooldowning==false){
            GameObject Closest=nearbyDetect.GetComponent<playerNearBy>().getClosest(5);
            if(Closest!=null){
                Attack(Closest);
            }
        }
        else if(fireballState.FireballEnable&&fireballState.Fireballcooldowning==true){
            skillController.skillImagepool[FireballNum].fillAmount+= (1/ fireballState.Fireballcastspeed*Time.deltaTime);
            if(skillController.skillImagepool[FireballNum].fillAmount>=1){
                fireballState.Fireballcooldowning=false;
            }
        }
        
    }
    void Attack(GameObject Closest){
        setImage();
        dir = Closest.transform.position-firepoint.transform.position;
        firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        if(fireballState.FireballFireNum>1){
            float angle=fireballState.FireballFireNum*10-fireballState.FireballFireNum*3;
            float fixangle= angle*2/(fireballState.FireballFireNum-1);
            for(int i = 1;i<=fireballState.FireballFireNum;i++){
                GameObject attackObject = Instantiate(fireball,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg+angle));
                angle-=fixangle;
                attackObject.GetComponent<FireBall>().fly();
            }
        }
        else{
        GameObject attackObject = Instantiate(fireball,firepoint.transform.position,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
        attackObject.GetComponent<FireBall>().fly();
        }
    }
    void setImage(){
        skillController.skillImagepool[FireballNum].fillAmount=0;
        fireballState.Fireballcooldowning=true;
    }
}
