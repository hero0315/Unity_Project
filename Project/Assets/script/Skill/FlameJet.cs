using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameJet : MonoBehaviour
{
    [SerializeField]private Animator anim;
    float continuetime;
    float timer;
    void Start(){
        continuetime=FlameJetState.FlameJetContinueTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=continuetime){
            anim.SetBool("Continue",false);
            Invoke("Destroyaftersec",0.4f);
        }
    }
    void Destroyaftersec(){
        Destroy(this.gameObject);
    }
}
