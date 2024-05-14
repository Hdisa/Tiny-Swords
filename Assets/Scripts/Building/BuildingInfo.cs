using UnityEngine;

[CreateAssetMenu]
public class BuildingInfo : ScriptableObject
{
    [Header("Crystal")] 
    public float crystalHealth;
    
    [Header("Mine")]
    public float mineHealth;
}
