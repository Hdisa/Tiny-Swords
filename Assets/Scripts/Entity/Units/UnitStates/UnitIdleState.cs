using UnityEngine;

public class UnitIdleState : StateMachineBehaviour
{
    private AttackController attackController;

    private static readonly int IsFollowing = Animator.StringToHash("isFollowing");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //проверка есть ли вражеская цель
        if (attackController.targetToAttack != null) animator.SetBool(IsFollowing, true);
    }
}
