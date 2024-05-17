using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RenderingOrderByY : MonoBehaviour
{
    [SerializeField] private float adjustmentMultiplier = 100;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        _spriteRenderer.sortingOrder = Mathf.FloorToInt(-transform.position.y * adjustmentMultiplier);
    }
}
