using UnityEngine;

[RequireComponent(typeof(Health))]
public class Mine : MonoBehaviour
{
    [SerializeField] private GameResources resources;
    [SerializeField] private float income;
    private Health hp;

    private void Start()
    {
        hp = GetComponent<Health>();
    }

    private void Update()
    {
        resources.coins += income * Time.deltaTime;
        hp.ReceiveDamage(2 * Time.deltaTime);
    }
}
