using UnityEngine;
using UnityEngine.AI;

public class UnitAttackState : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private AttackController attackController;

    public float stopAttackingDistance = 1.2f;
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        attackController = animator.GetComponent<AttackController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackController.targetToAttack != null && animator.transform.GetComponent<UnitMovement>().priorityMove == false)
        {
            agent.SetDestination(attackController.targetToAttack.position);
            
            var dealDamage = attackController.unitDamage;
            attackController.targetToAttack.GetComponent<EnemyAI>().ReceiveDamage(dealDamage);
            
            float distanceFromTarget =
                Vector2.Distance(attackController.targetToAttack.position, animator.transform.position);
            if (distanceFromTarget > stopAttackingDistance || attackController.targetToAttack == null)
            {
                animator.SetBool(IsAttacking, false);
            }
        }
    }
}
