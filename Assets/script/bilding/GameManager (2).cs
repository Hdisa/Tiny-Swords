using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject buildingToPlace;
    public CustomCursor cursor;
    public sell sell;
    public bool ess;

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

    public void SellBuilding(float prise)
    {
        if (sell.Sell >= prise)
        {
            sell.Sell -= prise;
            ess = true;
        }

        if (sell.Sell <= prise - 1)
        {
            ess = false;
        }
    }
    public void ConstructionBuilding(GameObject building)
    {
        if (ess == true)
        {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            buildingToPlace = building;
            Cursor.visible = false;
        }
    }
}
