using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject Setting;
    [SerializeField] GameObject Savesystem;
    private bool ismenuopen=false;
    void Update(){
        if(Input.GetKeyDown("escape")){
            if(playerState.canEsc){
                if(ismenuopen){
                returngame();
            }
            else{
                openmenu();
            }
            }
        }
    }
    public void quitgame(){
        SaveSystem.SavePlayerdata();
        Application.Quit();
    }
    public void returngame(){
        menu.SetActive(false);
        ismenuopen=false;
        eventController.depauseEvent.Invoke();
    }
    public void openmenu(){
        menu.SetActive(true);
        ismenuopen=true;
        eventController.pauseEvent.Invoke();
    }
    public void setting(){
        menu.SetActive(false);
        Setting.SetActive(true);
    }
    public void mainmenu(){
        eventController.depauseEvent.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
    public void restartgame(){
        this.gameObject.SetActive(false);
        eventController.depauseEvent.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("fightingScenes");
        playerState.restartAll();
        SaveSystem.SavePlayerdata();
    }
    
}
