using UnityEngine.Events;
using UnityEngine;
using TMPro;
public class eventController : MonoBehaviour
{
    public static UnityEvent pauseEvent;
    public static UnityEvent depauseEvent;
    public static UnityEvent<float,Vector3> damageEvent;
    [SerializeField]private TextMeshPro damageText;
    void Start()
    {
        if (pauseEvent == null)
            pauseEvent = new UnityEvent();
        pauseEvent.AddListener(pause);
        if (depauseEvent == null)
            depauseEvent = new UnityEvent();
        depauseEvent.AddListener(depause);
        if (damageEvent == null)
            damageEvent = new UnityEvent<float,Vector3>();
        damageEvent.AddListener(damage);
    }

    public void pause(){
        Time.timeScale = 0;
        FlameJetState.FlameJetcanmove=false;
    }
    public void depause(){
        Time.timeScale = 1;
        FlameJetState.FlameJetcanmove=true;
    }
    public void damage(float damage,Vector3 pos){
        TextMeshPro createText = Instantiate(damageText,new Vector3(pos.x,pos.y+0.6f,pos.z),Quaternion.identity);
        createText.text=""+(damage);
    }
}
