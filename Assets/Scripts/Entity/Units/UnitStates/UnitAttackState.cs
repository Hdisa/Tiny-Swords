using UnityEngine;
using UnityEngine.AI;

public class UnitAttackState : StateMachineBehaviour
{
    [SerializeField] private float stopAttackingDistance = 1.2f;
    
    private NavMeshAgent agent;
    private AttackController attackController;
    private Unit unit;
    private EnemyAI enemy;
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        attackController = animator.GetComponent<AttackController>();
        unit = animator.GetComponent<Unit>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackController.targetToAttack != null && !animator.transform.GetComponent<UnitMovement>().priorityMove)
        {
            var enemyTarget = attackController.targetToAttack.position;
            agent.SetDestination(enemyTarget);

            if (animator.GetComponent<AttackController>().canAttack)
            {
                var dealDamage = unit.GetComponent<AttackController>().damage;
                attackController.targetToAttack.GetComponent<Health>().ReceiveDamage(dealDamage);
                unit.GetComponent<AttackController>().canAttack = false;
                animator.SetBool(IsAttacking, false);
            }
        
            var distanceFromTarget = Vector2.Distance(attackController.targetToAttack.position, animator.transform.position);
            if (distanceFromTarget >= stopAttackingDistance || attackController.targetToAttack == null)
                animator.SetBool(IsAttacking, false);
        }
        animator.SetBool(IsAttacking, false);
    }
}
