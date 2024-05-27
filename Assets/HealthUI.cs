using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private GameObject castle;
    
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
       castle.GetComponent<Health>().OnHealthChanged += UpdateHealth;
    }


    private void UpdateHealth(float hp)
    {
        rect.localScale = new Vector3(hp, 1, 1);
    }
}
