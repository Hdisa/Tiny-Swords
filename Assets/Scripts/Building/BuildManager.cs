using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject buildingToPlace;
    public CustomCursor cursor;
    public GameResources resources;
    public bool ess;

    private float price;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null & cursor.onTriggerEnter != true)
        {
            Instantiate(buildingToPlace, cursor.transform.position, Quaternion.identity);
            buildingToPlace = null;
            cursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }

        ess = resources.coins >= price;
    }

    public void SellBuilding(float prise)
    {
        price = prise;
        if (ess)
        {
            resources.coins -= price;
        }
    }
    public void ConstructionBuilding(GameObject building)
    {
        if (ess)
        {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            buildingToPlace = building;
            Cursor.visible = false;
        }
    }
}
