using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{ 
    void Start(){
        if(!File.Exists(Application.persistentDataPath+"/player.txt")){
            string path = Application.persistentDataPath+"/player.txt";
            PlayerData data=new PlayerData();
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Create);
            formatter.Serialize(stream,data);
            stream.Close();
        }
    }
    public static void SavePlayerdata(){
        string path = Application.persistentDataPath+"/player.txt";
        PlayerData data=new PlayerData();
        BinaryFormatter formatter=new BinaryFormatter();
        FileStream stream = new FileStream(path,FileMode.Create);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static PlayerData LoadPlayerdata(){
        string path = Application.persistentDataPath+"/player.txt";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            playerState.level=data.level;
            playerState.exp=data.level;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Load Error!");
            return null;
        }
    }  
}
