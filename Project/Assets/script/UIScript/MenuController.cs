using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject Setting;
    private bool ismenuopen=false;
    void Update(){
        if(Input.GetKeyDown("escape")){
            if(ismenuopen){
                returngame();
            }
            else{
                openmenu();
            }
        }
    }
    public void quitgame(){
        Application.Quit();
    }
    public void returngame(){
        menu.SetActive(false);
        ismenuopen=false;
        Time.timeScale = 1;
    }
    public void openmenu(){
        menu.SetActive(true);
        ismenuopen=true;
        Time.timeScale = 0;
    }
    public void setting(){
        menu.SetActive(false);
        Setting.SetActive(true);
    }
    public void mainmenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
