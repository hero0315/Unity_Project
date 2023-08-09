using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointimer : MonoBehaviour
{
    [SerializeField]private Color color;
    [SerializeField]private SpriteRenderer spriteRenderer;
    void Update()
    {
        color.a-=5f*Time.deltaTime;
        spriteRenderer.color=color;
    }
}
