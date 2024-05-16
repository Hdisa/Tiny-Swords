using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TargetList")]
public class TargetList : ScriptableObject
{
    public IReadOnlyList<Targetable> Targetables => targets;
    [SerializeField]private List<Targetable> targets = new();

    public void RegisterTarget(Targetable newTarget)
    {
        if(!targets.Contains(newTarget)) targets.Add(newTarget);
    }

    public void UnRegisterTarget(Targetable targetable)
    {
        targets.Remove(targetable);
    }

    public void Clear() => targets.Clear();

    private void OnDisable()
    {
        targets.Clear();
    }
}