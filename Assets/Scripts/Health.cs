using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hp;

    public float HealthPoint
    {
        get => hp;
        set => hp = value;
    }

    //todo: переделать халс для зданий и юнитов

    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }
}
