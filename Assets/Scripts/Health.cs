using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hp;
    
    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }

    public void ReceiveDamage(float damage)
    {
        hp -= damage;
    }
}
