using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    public LayerMask ground;
    
    void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 ray2D = cam.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(ray2D);
        }
    }
}
