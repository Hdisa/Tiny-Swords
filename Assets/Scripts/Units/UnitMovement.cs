using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    public LayerMask ground;
    public bool priorityMove;
    private AttackController attackController;
    
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
            priorityMove = true;
            agent.SetDestination(ray2D);
        }

        //Если юнит достиг точки назначения
        if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
        {
            priorityMove = false;
            attackController.targetToAttack = null; // отрыв от врага, чтобы он не прилипал снова к противнику
        }
    }
}
