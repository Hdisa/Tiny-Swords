using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))] 

public class VolumePercent : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private string muteText = "0%";

    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        ChangeValue(slider.value);
        slider.onValueChanged.AddListener(ChangeValue);
    }

    private void ChangeValue(float v)
    {
        if (v < 0.001) _text.text = muteText;
        else _text.text = v.ToString("F0") + "%";
    }

}
