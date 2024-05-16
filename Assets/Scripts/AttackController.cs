using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 5;
    [SerializeField] private string attackable;
    public Transform targetToAttack;
    public float damage = 10;
    public bool canAttack;
    private float timer;
    private Camera cam;


    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 ray2D = cam.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(ray2D, Vector2.zero, Mathf.Infinity);
            if (!hit) return;

            Transform target = hit.transform;
            foreach (var unit in UnitSelection.Instance.selectedUnits)
            {
                var attack = unit.GetComponent<AttackController>();
                attack.targetToAttack = target;
            }
        }
        
        if (!canAttack) timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            canAttack = true;
            timer = timeToAttack;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(attackable) && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(attackable) && targetToAttack != null)
        {
            targetToAttack = other.transform;
        }
    }
}
