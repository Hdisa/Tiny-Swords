using UnityEngine;
using UnityEngine.AI;

public class UnitFollowState : StateMachineBehaviour
{
    private AttackController attackController;
    private NavMeshAgent agent;
    public float attackingDistance = 1f;
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    private static readonly int IsFollowing = Animator.StringToHash("isFollowing");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
        agent = animator.transform.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Пропадёт ли вражеская цель
        if (attackController.targetToAttack == null)
            animator.SetBool(IsFollowing, false);
        
        else
        {
            //Юнит идёт за врагом
            if (!animator.transform.GetComponent<UnitMovement>().priorityMove)
                agent.SetDestination(attackController.targetToAttack.position);
            
            //Добрался ли юнит достаточно близко к цели для атаки
            var distanceFromTarget =
                Vector2.Distance(attackController.targetToAttack.position, animator.transform.position);
            
            if (!(distanceFromTarget <= attackingDistance)) return;
            agent.SetDestination(animator.transform.position);
            animator.SetBool(IsAttacking, true);
        }
    }
}
