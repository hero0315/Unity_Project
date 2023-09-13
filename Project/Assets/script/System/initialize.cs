using UnityEngine;

public class initialize : MonoBehaviour
{
    [SerializeField]SkillController skillController;
    void Awake(){
        skillController.skillpool[0]="FireBall";
    }
}
