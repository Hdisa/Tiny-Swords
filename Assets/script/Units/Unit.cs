using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
