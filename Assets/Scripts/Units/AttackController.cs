using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;
    public float unitDamage = 10;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && targetToAttack == null)
            targetToAttack = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && targetToAttack != null)
            targetToAttack = null;
    }
}
