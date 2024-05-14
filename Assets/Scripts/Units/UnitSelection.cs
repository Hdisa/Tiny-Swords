using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public List<GameObject> units = new ();
    public List<GameObject> selectedUnits = new ();

    private static UnitSelection instance;
    public static UnitSelection Instance => instance;
    
    public LayerMask attackable;
    private Camera cam;

    public void Awake()
    {
        //Если этот экземпляр уже существует
        if (instance != null && instance != this)
            Destroy(gameObject); //то уничтожаем
        else
            instance = this; //создаём экземпляр
        
        cam = Camera.main;
    }

    private void Update()
    {
        if (selectedUnits.Count == 0) return;

        Vector2 ray2D = cam.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(ray2D, Vector2.zero, Mathf.Infinity, attackable);
        if (!hit) return;

        Transform target = hit.transform;
        foreach (var unit in selectedUnits)
        {
            var attackController = unit.GetComponent<AttackController>();
            if (attackController != null) attackController.targetToAttack = target;
        }
    }

    public void ClickSelect(GameObject unit)
    {
        DeselectAll();
        selectedUnits.Add(unit);
        unit.transform.GetChild(0).gameObject.SetActive(true);
        unit.GetComponent<UnitMovement>().enabled = true;
    }

    public void ShiftClickSelect(GameObject unit)
    {
        if (!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
            unit.transform.GetChild(0).gameObject.SetActive(true);
            unit.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
            selectedUnits.Remove(unit);
        }
            
    }
    
    public void DragSelect(GameObject unit)
    {
        if (!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
            unit.transform.GetChild(0).gameObject.SetActive(true);
            unit.GetComponent<UnitMovement>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in selectedUnits)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        selectedUnits.Clear();
    }

    public void Deselect(GameObject unit)
    {
        unit.transform.GetChild(0).gameObject.SetActive(false);
        selectedUnits.Remove(unit);
    }
}
