using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int level;
    public float exp;
    public PlayerData(){
        level=playerState.level;
        exp=playerState.exp;
    }
}
