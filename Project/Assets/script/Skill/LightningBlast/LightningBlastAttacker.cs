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
        GameObject Far=nearbyDetect.GetComponent<LightningBlastDetect>().getFar();
        if(Far!=null){
            setImage();
            dir=Far.transform.position-firepoint.transform.position;
            firepoint.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
            float distance = Vector3.Distance(firepoint.transform.position,Far.transform.position);
            GameObject attackObject = Instantiate(LightningBlast,(Far.transform.position+firepoint.transform.position)/2,Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg));
            attackObject.transform.localScale=new Vector3(distance*2f/10f,0.25f,0.25f);
            attackObject.GetComponent<LightningBlast>().setTarget(Far);
        }
    }
    void setImage(){
        skillController.skillImagepool[LightningBlastNum].fillAmount=0;
        lightningblastState.LightningBlastcooldowning=true;
    }
}
