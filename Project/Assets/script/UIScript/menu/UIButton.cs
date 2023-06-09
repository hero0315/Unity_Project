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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
    public void restartgame(){
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("fightingScenes");
        playerState.restartAll();
        SaveSystem.SavePlayerdata();
    }
    
}
