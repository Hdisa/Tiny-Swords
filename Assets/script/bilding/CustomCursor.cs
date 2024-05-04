using System;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public bool onTriggerEnter = false;

    private Color color = Color.white;

    private Renderer rend;
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        
        if (onTriggerEnter == true)
        {
            color = Color.red;
        }
        if (onTriggerEnter != true)
        {
            color = Color.blue;
        }
        rend.material.color = color;
    }

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other1) 
    {
        onTriggerEnter = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerEnter = false;
    }
}
