using UnityEngine;

public class Targetable : MonoBehaviour
{
    [field: SerializeField] public float meleeDistance { get; private set; }

    [SerializeField] private TargetList myList;

    private void OnEnable() => myList.RegisterTarget(this);

    private void OnDisable() => myList.UnRegisterTarget(this);
}
