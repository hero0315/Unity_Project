using UnityEngine;

public class LightningBlastAttacker : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private Transform firepoint;
    [SerializeField] SkillController skillController;
    [SerializeField]private GameObject nearbyDetect;
    [SerializeField]private GameObject LightningBlast;
    private int LightningBlastNum;
    public void setLightningBlastNum(int num){
        LightningBlastNum=num;
    }
    void Update()
    {
        if(lightningblastState.LightningBlastEnable&&fireballState.Fireballcooldowning==false){
            Attack();
        }
        else if(lightningblastState.LightningBlastEnable&&lightningblastState.LightningBlastcooldowning==true){
            skillController.skillImagepool[LightningBlastNum].fillAmount+= (1/ lightningblastState.LightningBlastcastspeed*Time.deltaTime);
            if(skillController.skillImagepool[LightningBlastNum].fillAmount>=1){
                lightningblastState.LightningBlastcooldowning=false;
            }
        }
    }
    void Attack(){
        GameObject Closest=nearbyDetect.GetComponent<playerNearBy>().getClosest();
        if(Closest!=null){
            setImage();
            dir=Closest.transform.position-firepoint.transform.position;
            firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
            float distance = Vector3.Distance(firepoint.transform.position,Closest.transform.position);
            GameObject attackObject = Instantiate(LightningBlast,(Closest.transform.position+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
            attackObject.transform.localScale=new Vector3(distance*2f/10f,0.25f,0.25f);
            attackObject.GetComponent<LightningBlast>().setTarget(Closest);
        }
    }
    void setImage(){
        skillController.skillImagepool[LightningBlastNum].fillAmount=0;
        lightningblastState.LightningBlastcooldowning=true;
    }
}
