using TMPro;
using UnityEngine;



public class sellUI : MonoBehaviour
{
    public sell sellGet;

    public TextMeshProUGUI sellMonne;
    
    void Start()
    {
        sellMonne = GetComponentInChildren<TextMeshProUGUI>();
    }

    
    void Update()
    {
        UI();
    }

    public void UI()
    {
        sellMonne.text = sellGet.Sell.ToString();
    }
}
