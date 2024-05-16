using System;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Health), typeof(NavMeshAgent), typeof(AttackController))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject mainObject;
    [SerializeField] private TargetList viableTargets;
    private NavMeshAgent agent;
    private AttackController attackController;

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
        attackController = GetComponent<AttackController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        state = State.Choose;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Chase:
                agent.SetDestination(mainObject.transform.position);
                //что делать
                //как переключаться и куда
                if (Vector3.Distance(transform.position, target.transform.position) <= target.meleeDistance)
                {
                    state = State.Attack;
                    //запуск анимации
                    break;
                }
                break;
            case State.Attack:
                //что делать
                //как переключаться и куда
                break;
            case State.Choose:
                //как он выбирает цель?
                if( !viableTargets.Targetables.Any()) break;
                target = viableTargets.Targetables.Aggregate((closest, next)  =>  //очень сильное колдунство, выберет ближайший из списка
                    Vector3.Distance(next.transform.position, transform.position) < Vector3.Distance(closest.transform.position, transform.position)? next: closest );
                //как переключаться и куда
                state = State.Chase;
                break;
        }
    }
    
    
}
