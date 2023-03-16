using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [System.Serializable]
    public class Resolution{
        public int Horizontal;
        public int Vertical;
    }
    [SerializeField]private Text text;
    [SerializeField]Toggle fullscreenToggle,vsyncToggle;
    [SerializeField]private List<Resolution> ResolutionList;
    [SerializeField]private GameObject menu;
    [SerializeField]private GameObject Setting;
    private int ResolutionNum=0;
    private bool isfullscreen=true;
    void Start(){
        fullscreenToggle.isOn=Screen.fullScreen;
        if(QualitySettings.vSyncCount==0){
            vsyncToggle.isOn=false;
        }
        else{
            vsyncToggle.isOn=true; 
        }
        Screen.SetResolution(ResolutionList[0].Horizontal,ResolutionList[0].Vertical,fullscreenToggle.isOn);
        text.text=ResolutionList[0].Horizontal+" X "+ResolutionList[0].Vertical;
    }
    public void changeFullscreen(){
        if(isfullscreen==false){
            fullscreenToggle.isOn=true;
            isfullscreen=true;
        }
        else{
            fullscreenToggle.isOn=false; 
            isfullscreen=false;
        }
    }
    public void changeVsync(){
        if(QualitySettings.vSyncCount==0){
            vsyncToggle.isOn=true;
            QualitySettings.vSyncCount=1;
        }
        else{
            vsyncToggle.isOn=false; 
            QualitySettings.vSyncCount=0;
        }
    }

    public void changeResolution(){
        
        if(ResolutionNum==ResolutionList.Count-1){
            ResolutionNum=0;
        }
        else{
            ResolutionNum+=1;
        }
        text.text=ResolutionList[ResolutionNum].Horizontal+" X "+ResolutionList[ResolutionNum].Vertical;
        Screen.SetResolution(ResolutionList[ResolutionNum].Horizontal,ResolutionList[ResolutionNum].Vertical,fullscreenToggle.isOn);
    }
    public void Return(){
        menu.SetActive(true);
        Setting.SetActive(false);
    }
}
