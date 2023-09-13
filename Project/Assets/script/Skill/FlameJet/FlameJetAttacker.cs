using UnityEngine;

public class FlameJetAttacker : MonoBehaviour
{
    [SerializeField] SkillController skillController;
    [SerializeField]private GameObject FlameJet;
    private int FlameJetNum;
    public void setFlameJetNum(int num){
        FlameJetNum=num;
    }
    void Update()
    {
        if(FlameJetState.FlameJetEnable&&FlameJetState.FlameJetcooldowning){
            skillController.skillImagepool[FlameJetNum].fillAmount+= (1/ FlameJetState.FlameJetcooldown*Time.deltaTime);
            if(skillController.skillImagepool[FlameJetNum].fillAmount>=1){
                FlameJetState.FlameJetcooldowning=false;
            }
        }
        else if(FlameJetState.FlameJetEnable&&!FlameJetState.FlameJetcooldowning){
            Attack();
            skillController.skillImagepool[FlameJetNum].fillAmount=0;
        }
    }
    void Attack(){
        FlameJet.SetActive(true);
    }
}
