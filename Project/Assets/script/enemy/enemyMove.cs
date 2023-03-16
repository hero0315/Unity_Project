using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    private void Update(){
        if(playerController.playpos.position.x<transform.position.x){
            SpriteRenderer.flipX = true;
        }
        else{
            SpriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position,playerController.playpos.position,movespeed*Time.deltaTime);
    }
}
