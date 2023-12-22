using TMPro;
using UnityEngine;
using System.Collections;
public class Timer : MonoBehaviour
{
    public static float time=0f;
    private float min=0;
    [SerializeField]private TextMeshProUGUI timeText;
    void Awake()
    {
        time=0;
        StartCoroutine(Timepast());
    }
    IEnumerator Timepast(){
        while(true){
            time+=1;
            min=Mathf.Floor(time/60);
            if(min==0){
                if(time%60<10){
                    timeText.text="00" +" : 0" +time%60;
                }
                else{
                    timeText.text="00" +" : " +time%60;
                }
            }
            else if(min<10){
                if(time%60<10){
                    timeText.text="0" +min+" : 0" +time%60;
                }
                else{
                    timeText.text="0"+min +" : " +time%60;
                }
            }
            else{
                if(time%60<10){
                    timeText.text= +min+" : 0" +time%60;
                }
                else{
                timeText.text=  min +" : " +time%60;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public float gettime(){
        return time;
    }
}
