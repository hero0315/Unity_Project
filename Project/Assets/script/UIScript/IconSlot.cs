using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class IconSlot : MonoBehaviour,IDropHandler
{
    [SerializeField]private GameObject slotIcon;
    [SerializeField]private GameObject skillController;
    [SerializeField]private int serialNumber;
    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag!=null){
            if(slotIcon.GetComponent<Image>().sprite==null){
                slotIcon.GetComponent<Image>().color= new Color(255f,255f,255f,255f);
                for(int i =0;i<skillController.GetComponent<SkillController>().skillpools.Count;i++){
                    if(eventData.pointerDrag.GetComponent<Image>().sprite.name==skillController.GetComponent<SkillController>().skillpools[i].skillname){
                        skillController.GetComponent<SkillController>().swapskill(i,serialNumber);
                        slotIcon.GetComponent<Image>().sprite=eventData.pointerDrag.GetComponent<Image>().sprite;
                        eventData.pointerDrag.GetComponent<Image>().sprite=null;
                        eventData.pointerDrag.GetComponent<Image>().color= new Color(255f,255f,255f,0f);
                        break;
                    }
                }
            }
            else if(slotIcon.GetComponent<Image>().sprite!=eventData.pointerDrag.GetComponent<Image>().sprite){
                bool changed=false;
                for(int i =0;i<skillController.GetComponent<SkillController>().skillpools.Count;i++){
                    for(int j =0;j<skillController.GetComponent<SkillController>().skillpools.Count;j++){
                        if(i==j){
                            continue;
                        }
                        else if(slotIcon.GetComponent<Image>().sprite.name==skillController.GetComponent<SkillController>().skillpools[i].skillname&&eventData.pointerDrag.GetComponent<Image>().sprite.name==skillController.GetComponent<SkillController>().skillpools[j].skillname){
                            skillController.GetComponent<SkillController>().swapskill(i,j);
                            changed=true;
                            break;
                        }
                    }
                    if(changed==true){
                        break;
                    }
                }
                Sprite temp = slotIcon.GetComponent<Image>().sprite;
                slotIcon.GetComponent<Image>().sprite=eventData.pointerDrag.GetComponent<Image>().sprite;
                eventData.pointerDrag.GetComponent<Image>().sprite=temp;
            }
        }
    }
}
