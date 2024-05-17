using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Health), typeof(NavMeshAgent), typeof(AttackController))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private TargetList viableTargets;
    private NavMeshAgent agent;
    private AttackController attackController;

    //Ниже пример реализации машины состояния для врагов.
    private enum State
    {
        Choose,
        Chase,
        Attack
    }

    [SerializeField] private Targetable target;

    private State state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        attackController = GetComponent<AttackController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        state = State.Choose;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Chase:
                //что делать
                //как переключаться и куда
                if (target != null && Vector3.Distance(transform.position, target.transform.position) <= target.meleeDistance && attackController.canAttack)
                {
                    state = State.Attack;
                    //запуск анимации
                    break;
                }
                state = State.Choose;
                break;
            case State.Attack:
                //что делать
                target.GetComponent<Health>().ReceiveDamage(attackController.damage);
                attackController.canAttack = false;
                if (target != null) state = State.Chase;
                state = State.Choose;
                break;
            case State.Choose:
                //как он выбирает цель?
                if( !viableTargets.Targetables.Any()) break;
                target = viableTargets.Targetables.Aggregate((closest, next)  =>  //очень сильное колдунство, выберет ближайший из списка
                    Vector3.Distance(next.transform.position, transform.position) < Vector3.Distance(closest.transform.position, transform.position)? next: closest );
                //как переключаться и куда
                agent.SetDestination(target.transform.position);
                state = State.Chase;
                break;
        }
    }
}
