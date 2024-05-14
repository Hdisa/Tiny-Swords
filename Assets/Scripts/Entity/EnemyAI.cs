using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject mainObject;
    private NavMeshAgent agent;
    private Health hp;

    private void Awake()
    {
        hp = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(mainObject.transform.position);
    }

    public void ReceiveDamage(float damage)
    {
        hp.HealthPoint -= damage;
    }
}
