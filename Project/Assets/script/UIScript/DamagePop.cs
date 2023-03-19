using UnityEngine;
using TMPro;

public class DamagePop : MonoBehaviour
{
    private float disappearTimer=0.5f;
    [SerializeField]private Color textColor;
    [SerializeField]private TextMeshPro textMesh;
    void Update()
    {
        transform.position+=new Vector3(0,1f)*Time.deltaTime;
        disappearTimer-=Time.deltaTime;
        if(disappearTimer<0){
            float disappearSpeed=5f;
            textColor.a-=disappearSpeed*Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a<0){
                Destroy(gameObject);
            }
        }
    }
}
