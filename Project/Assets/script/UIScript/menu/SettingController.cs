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
    [SerializeField]Toggle fullscreenToggle,vsyncToggle,showfpsToggle;
    [SerializeField]private List<Resolution> ResolutionList;
    [SerializeField]private GameObject menu;
    [SerializeField]private GameObject Setting;
    [SerializeField]private GameObject fps;
    private int ResolutionNum=0;
    void Start(){
        fullscreenToggle.isOn=Screen.fullScreen;
        showfpsToggle.isOn=true;
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
        if(fullscreenToggle.isOn){
            Screen.fullScreen=true;
        }
        else{
            Screen.fullScreen=false;
        }
    }
    public void changeVsync(){
        if(vsyncToggle.isOn){
            QualitySettings.vSyncCount=1;
        }
        else{
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
    public void showfps(){
        if(showfpsToggle.isOn){
            fps.SetActive(true);
        }
        else{
            fps.SetActive(false);
        }
    }
}
