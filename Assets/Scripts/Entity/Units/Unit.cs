using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health), typeof(NavMeshAgent), typeof(AttackController))]
public class Unit : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent agent;

    private void Start()
    {
        UnitSelection.Instance.units.Add(gameObject);
        transform.parent = null;
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.units.Remove(gameObject);
        UnitSelection.Instance.selectedUnits.Remove(gameObject);
    }
}
