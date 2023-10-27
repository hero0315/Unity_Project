using UnityEngine.Events;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class eventController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private TextMeshPro coinpop;
    public static UnityEvent pauseEvent;
    public static UnityEvent depauseEvent;
    public static UnityEvent<float,Vector3> damageEvent;
    public static UnityEvent<Vector3> coinDropEvent;
    public static UnityEvent<Vector3> itemDropEvent;
    public static UnityEvent<Vector3> eatcoinEvent;
    public static UnityEvent eatMagnetEvent;
    [SerializeField]private Transform coinbag;
    [SerializeField]private Transform magnetbag;
    [SerializeField]private TextMeshPro damageText;
    [SerializeField]private GameObject coin;
    [SerializeField]private GameObject magnet;
    [SerializeField]private Transform player;
    TextMeshPro createText;
    private List<GameObject> coinlist=new List<GameObject>();
    void Start()
    {
        if (pauseEvent == null)
            pauseEvent = new UnityEvent();
        pauseEvent.AddListener(pause);

        if (depauseEvent == null)
            depauseEvent = new UnityEvent();
        depauseEvent.AddListener(depause);

        if (damageEvent == null)
            damageEvent = new UnityEvent<float,Vector3>();
        damageEvent.AddListener(damage);

        if (coinDropEvent == null)
            coinDropEvent = new UnityEvent<Vector3>();
        coinDropEvent.AddListener(coinDrop);

        if (itemDropEvent == null)
            itemDropEvent = new UnityEvent<Vector3>();
        itemDropEvent.AddListener(itemDrop);

        if (eatMagnetEvent == null)
            eatMagnetEvent = new UnityEvent();
        eatMagnetEvent.AddListener(eatmagnet);

        if (eatcoinEvent == null)
            eatcoinEvent = new UnityEvent<Vector3>();
        eatcoinEvent.AddListener(eatcoin);
    }

    public void pause(){
        Time.timeScale = 0;
        FlameJetState.FlameJetcanmove=false;
    }
    public void depause(){
        Time.timeScale = 1;
        FlameJetState.FlameJetcanmove=true;
    }
    public void damage(float damage,Vector3 pos){
        TextMeshPro createText = Instantiate(damageText,new Vector3(pos.x,pos.y+0.6f,pos.z),Quaternion.identity);
        createText.text=""+(damage);
    }
    public void coinDrop(Vector3 pos){
        GameObject _coin = Instantiate(coin,pos,Quaternion.identity,coinbag);
        coinlist.Add(_coin);
    }
    public void itemDrop(Vector3 pos){
        int random=Random.Range(1,101);
        if(random<=50){
            coinDrop(pos);
        }
        if(random<=5){
            magnetDrop(pos);
        }
    }
    public void magnetDrop(Vector3 pos){
        GameObject _magnet = Instantiate(magnet,pos,Quaternion.identity,magnetbag);
    }
    public void eatmagnet(){
        foreach(coin obj in coinbag.GetComponentsInChildren<coin>()){
            obj.GetComponent<coin>().startfly();
        }
    }
    public void eatcoin(Vector3 pos){
        playerState.coin+=10;
        coinText.text= playerState.coin+"$";
        TextMeshPro coin = Instantiate(coinpop,new Vector3(pos.x,pos.y+0.6f,pos.z),Quaternion.identity);
        coin.text=""+10+"$";
    }
}
