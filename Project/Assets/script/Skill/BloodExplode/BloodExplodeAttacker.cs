using UnityEngine;
using UnityEngine.Events;

public class BloodExplodeAttacker : MonoBehaviour
{
    public static UnityEvent<Vector3> monsterdead;
    [SerializeField] SkillController skillController;
    [SerializeField]GameObject BloodExplode;
    [SerializeField]GameObject BloodFloor;
    int BloodExplodeNum;
    void Start()
    {
        if (monsterdead == null)
            monsterdead = new UnityEvent<Vector3>();
        monsterdead.AddListener(monsterDead);
    }
    void Update(){
        if(BloodExplodeState.BloodExplodecooldowning&&BloodExplodeState.BloodExplodeEnable){
            skillController.skillImagepool[BloodExplodeNum].fillAmount+= (1/ BloodExplodeState.BloodExplodecooldown*Time.deltaTime);
            if(skillController.skillImagepool[BloodExplodeNum].fillAmount>=1){
                BloodExplodeState.BloodExplodecooldowning=false;
            }
        }
    }
    public void monsterDead(Vector3 pos){
        if(BloodExplodeState.BloodExplodecooldowning==false&&BloodExplodeState.BloodExplodeEnable){
            Instantiate(BloodExplode,pos,Quaternion.identity);
            Instantiate(BloodFloor,pos,Quaternion.identity);
            BloodExplodeState.BloodExplodecooldowning=true;
            skillController.skillImagepool[BloodExplodeNum].fillAmount=0;
        }
    }
    public void setBloodExplodeNum(int num){
        BloodExplodeNum=num;
    }
}
