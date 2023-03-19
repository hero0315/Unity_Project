using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z-10);
    }
}
