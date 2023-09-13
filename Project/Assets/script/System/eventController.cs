using UnityEngine.Events;
using UnityEngine;

public class eventController : MonoBehaviour
{
    public static UnityEvent pauseEvent;
    public static UnityEvent depauseEvent;
    void Start()
    {
        if (pauseEvent == null)
            pauseEvent = new UnityEvent();
        pauseEvent.AddListener(pause);
        if (depauseEvent == null)
            depauseEvent = new UnityEvent();
        depauseEvent.AddListener(depause);
    }

    public void pause(){
        Time.timeScale = 0;
        FlameJetState.FlameJetcanmove=false;
    }
    public void depause(){
        Time.timeScale = 1;
        FlameJetState.FlameJetcanmove=true;
    }
}
