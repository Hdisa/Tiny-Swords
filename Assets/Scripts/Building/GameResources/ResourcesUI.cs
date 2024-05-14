using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    public GameResources resources;
    public TextMeshProUGUI coinsText;
    
    void Start()
    {
        coinsText = GetComponentInChildren<TextMeshProUGUI>();
    } 
    
    void Update()
    {
        coinsText.text = resources.coins.ToString("F0");
    }
}
