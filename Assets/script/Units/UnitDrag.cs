using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    [SerializeField] private RectTransform box;

    private Camera cam;
    private Rect selectionBox;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private void Start()
    {
        cam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
            SelectUnits();
        }
    }

    private void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        box.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        box.sizeDelta = boxSize;
    }

    private void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        
        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        foreach (var unit in UnitSelection.Instance.units)
        {
            if (selectionBox.Contains(cam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitSelection.Instance.DragSelect(unit);
            }
        }
    }
}
