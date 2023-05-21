using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class DragIcon : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField]private Canvas canvas;
    [SerializeField]private CanvasGroup canvasGroup;
    [SerializeField]List<CanvasGroup> othercanvasGroup = new List<CanvasGroup>();
    [SerializeField]private Transform father;
    private int temp;
    Vector3 originpos;
    void Start(){
        rectTransform=GetComponent<RectTransform>();
        canvasGroup=GetComponent<CanvasGroup>();
        originpos=rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData){
        temp=father.GetSiblingIndex();
        father.SetAsLastSibling();
        playerState.canplayermove=false;
        canvasGroup.alpha=.6f;
        canvasGroup.blocksRaycasts=false;
        foreach(CanvasGroup cg in othercanvasGroup){
            cg.blocksRaycasts=false;
        }
    }
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition+=eventData.delta/canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData){
        father.SetSiblingIndex(temp);
        playerState.canplayermove=true;
        canvasGroup.alpha=1f;
        canvasGroup.blocksRaycasts=true;
        foreach(CanvasGroup cg in othercanvasGroup){
            cg.blocksRaycasts=true;
        }
        rectTransform.anchoredPosition=originpos;
    }
}
