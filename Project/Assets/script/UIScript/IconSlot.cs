using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class IconSlot : MonoBehaviour,IDropHandler
{
    [SerializeField]private GameObject slotIcon;
    [SerializeField]private GameObject skillController;
    class skillpool{
        public GameObject skill;
        public string skillname;
        public string buttonName;
        [System.NonSerialized]
        public float cooldown;
        public float spellcastspeed=1;
        public GameObject SkillIcon;
        public Image skillImage; 
        [System.NonSerialized]
        public bool iscooldowning=false;
        public void setcastspeed(float castspeed){
            spellcastspeed=castspeed;
        }
    }
    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag!=null){
            if(slotIcon.GetComponent<Image>().sprite!=eventData.pointerDrag.GetComponent<Image>().sprite){
                for(int i =0;i<skillController.GetComponent<SkillController>().skillpools.Count;i++){
                    for(int j =0;j<skillController.GetComponent<SkillController>().skillpools.Count;j++){
                        if(slotIcon.GetComponent<Image>().sprite.name==skillController.GetComponent<SkillController>().skillpools[i].skillname&&eventData.pointerDrag.GetComponent<Image>().sprite.name==skillController.GetComponent<SkillController>().skillpools[j].skillname){
                            skillController.GetComponent<SkillController>().swapskill(i,j);
                        }
                    }
                }
                Sprite temp = slotIcon.GetComponent<Image>().sprite;
                slotIcon.GetComponent<Image>().sprite=eventData.pointerDrag.GetComponent<Image>().sprite;
                eventData.pointerDrag.GetComponent<Image>().sprite=temp;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
            }
            
        }
    }
}
