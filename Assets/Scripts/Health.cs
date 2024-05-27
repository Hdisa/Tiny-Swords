using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hp;
    private float maxHealth;
    
    public Action<float> OnHealthChanged;

    private void Start()
    {
        maxHealth = hp;
    }

    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }

    public void ReceiveDamage(float damage)
    {
        hp -= damage;
        OnHealthChanged?.Invoke(hp / maxHealth);
    }
}
