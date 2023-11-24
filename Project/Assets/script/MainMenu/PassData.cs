using UnityEngine;

public class PassData : MonoBehaviour
{
    public string playerName;
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void setName(string name){
        playerName=name;
    }
}
