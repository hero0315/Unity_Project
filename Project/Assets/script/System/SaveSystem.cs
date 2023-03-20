using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SavePlayerdata(){
        BinaryFormatter formatter=new BinaryFormatter();
        string path=Application.persistentDataPath+"/player.data";
        FileStream stream = new FileStream(path,FileMode.Create);
        PlayerData data=new PlayerData();
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static void LoadPlayerdata(){
        string path = Application.persistentDataPath+"/player.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            playerState.level=data.level;
            playerState.exp=data.level;
            stream.Close();
        }
        else{
            Debug.Log("Save Error!");
        }
    }
    void Awake(){
        LoadPlayerdata();
    }
}
