using UnityEngine;

public class Cellet : MonoBehaviour
{
    public GameObject cube;

    private Camera _cam;

    public LayerMask LayerMask;
    
    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Instantiate(cube, new Vector3(rayHit.point.x, rayHit.point.y), Quaternion.identity);
        }
        
    }
}
