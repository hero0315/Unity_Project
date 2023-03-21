[System.Serializable]
public class PlayerData
{
    public int level;
    public float exp;
    public PlayerData(){
        level=playerState.level;
        exp=playerState.exp;
    }
}
