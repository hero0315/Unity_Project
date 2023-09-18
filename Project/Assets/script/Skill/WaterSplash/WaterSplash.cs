using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroyafter",0.8f);
    }

    // Update is called once per frame
    void Destroyafter(){
        Destroy(this.gameObject);
    }
}
