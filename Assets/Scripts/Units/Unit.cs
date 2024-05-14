using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent agent;

    private void Start()
    {
        UnitSelection.Instance.units.Add(gameObject);
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.units.Remove(gameObject);
    }
}
