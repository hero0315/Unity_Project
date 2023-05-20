using UnityEngine;
using TMPro;

public class fpsdetect : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private int count;
    private float deltaTime;
    public int FrameRate;
    private float fps;
    void Start(){
        Application.targetFrameRate = FrameRate;
    }
    void Update()
    {
        count++;
        deltaTime += Time.deltaTime;
        if (deltaTime >= 0.5f)
        {
            fps = count/deltaTime;
            count = 0;
            deltaTime = 0;
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
        }
    }
}
