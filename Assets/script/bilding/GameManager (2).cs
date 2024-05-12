using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject buildingToPlace;
    public CustomCursor cursor;
    public sell sell;
    public bool ess;

    private float _prise;

        private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null & cursor.onTriggerEnter != true)
        {
            Instantiate(buildingToPlace, cursor.transform.position, Quaternion.identity);
            buildingToPlace = null;
            cursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }
        if (sell.Sell >= _prise)
        {
            ess = true;
        }

        if (sell.Sell <= _prise - 1)
        {
            ess = false;
        }
    }

    public void SellBuilding(float prise)
    {
        _prise = prise;
        if (ess)
        {
            sell.Sell -= _prise;
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
