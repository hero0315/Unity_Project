using UnityEngine;

public class FlameJet : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField]private Animator anim;
    float continuetime;
    float timer;
    private Vector3 mousepos;
    [SerializeField]private Camera cam;
    void Start(){
        continuetime=FlameJetState.FlameJetContinueTime;
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=continuetime){
            anim.SetBool("Continue",false);
            Invoke("unActiveAftersec",0.4f);
        }
        if(FlameJetState.FlameJetcanmove){
            mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z=0;
            dir=mousepos-this.transform.position;
            this.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg-90f);
        }
    }
    void unActiveAftersec(){
        timer=0;
        FlameJetState.FlameJetcooldowning=true;
        this.gameObject.SetActive(false);
    }
}
