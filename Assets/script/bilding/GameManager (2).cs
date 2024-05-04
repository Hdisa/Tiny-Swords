using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject buildingToPlace;
    public CustomCursor cursor;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null & cursor.onTriggerEnter != true)
        {
            Instantiate(buildingToPlace, cursor.transform.position, Quaternion.identity);
            buildingToPlace = null;
            cursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }
        
    }

    public void ConstructionBuilding(GameObject building)
    {
        cursor.gameObject.SetActive(true);
        cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
        buildingToPlace = building;
        Cursor.visible = false;
    }
}
