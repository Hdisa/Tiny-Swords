using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public bool onTriggerEnter;
    private Color color = Color.white;
    private Renderer rend;
    
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        
        if (onTriggerEnter)
        {
            color = Color.red + Color.white;
        }
        if (!onTriggerEnter)
        {
            color = Color.cyan;
        }
        rend.material.color = color;
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        onTriggerEnter = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerEnter = false;
    }
}
