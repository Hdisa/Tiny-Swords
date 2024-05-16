using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health), typeof(NavMeshAgent), typeof(AttackController))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject mainObject;
    private NavMeshAgent agent;
    private AttackController attackController;

    private void Awake()
    {
        attackController = GetComponent<AttackController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(mainObject.transform.position);
    }
}
