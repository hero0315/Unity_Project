using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time=0f;
    private float min=0;
    [SerializeField]private TextMeshProUGUI timeText;
    void Start()
    {
        InvokeRepeating("PastaSecond",1f,1f);
    }
    void PastaSecond(){
        time+=1;
        min=Mathf.FloorToInt(time/60);
        if(min==0){
            timeText.text="00" +" : " +time%60;
        }
        else if(min<10){
            timeText.text="0" +" : " +time%60;
        }
        else{
            timeText.text=+min +" : " +time%60;
        }
        if(time%60<10){
            timeText.text="00" +" : 0" +time%60;
        }
    }
}
