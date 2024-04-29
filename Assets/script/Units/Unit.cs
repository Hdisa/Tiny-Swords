using System;
using UnityEngine;
using UnityEngine.AI;

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
