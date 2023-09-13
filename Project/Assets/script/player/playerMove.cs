using UnityEngine.EventSystems;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]private Animator myAnimator;
    private SpriteRenderer SpriteRenderer;
    private Vector3 mousepos;
    [SerializeField]private Camera cam;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&&!EventSystem.current.IsPointerOverGameObject()&&playerState.canplayermove)
        {
            MouseFollow();
            myAnimator.SetInteger("state", 1);
        }
        else if(transform.position!=mousepos){
            transform.position = Vector3.MoveTowards(transform.position,mousepos,playerState.playerMovespeed*Time.deltaTime);
        }
        else{
            myAnimator.SetInteger("state", 0);
        }
        
    }
    public void MouseFollow()
    {
        mousepos= cam.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z=0;
        transform.position = Vector3.MoveTowards(transform.position,mousepos,playerState.playerMovespeed*Time.deltaTime);
        if(mousepos.x<transform.position.x){
            SpriteRenderer.flipX = true;
        }
        else{
            SpriteRenderer.flipX = false;
        }
    }
}