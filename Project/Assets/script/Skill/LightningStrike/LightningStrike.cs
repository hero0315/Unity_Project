using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public void setfalse(){
        Invoke("set",0.5f);
    }
    void set(){
        this.gameObject.SetActive(false);
    }
}
