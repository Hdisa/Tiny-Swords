using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    public bool priorityMove;
    private AttackController attackController;
    private bool isRightSide = true;
    
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
            foreach (var unit in UnitSelection.Instance.selectedUnits)
            {
                priorityMove = true;
                unit.GetComponent<NavMeshAgent>().SetDestination(ray2D);
                unit.GetComponent<AttackController>().targetToAttack = null;
            }
            UnitSelection.Instance.DeselectAll();
            Vector3 movementdd = ray2D;
            Vector2 movement = movementdd.normalized;

            if (movement.x > 0 && !isRightSide)
                Spin();
            
            else if (movement.x < 0 && isRightSide)
                Spin();
        }

        //Если юнит достиг точки назначения
        if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
            priorityMove = false;
        
    }
    
    void Spin()
    {
        isRightSide = !isRightSide;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
