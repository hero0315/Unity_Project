using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void fight(){
        SceneManager.LoadScene("fightingScenes");
    }
}
