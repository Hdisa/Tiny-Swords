using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera cam;

    public LayerMask clickable;
    public LayerMask ground;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray2D = cam.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(ray2D, Vector2.zero, Mathf.Infinity, clickable);
            if (hit)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    UnitSelection.Instance.ShiftClickSelect(hit.collider.gameObject);
                else
                    UnitSelection.Instance.ClickSelect(hit.collider.gameObject);
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                    UnitSelection.Instance.DeselectAll();
            }
        }
    }
}
