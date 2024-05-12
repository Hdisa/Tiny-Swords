using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundMusic : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string groupID;
    [SerializeField] private int minValue = -80;
    [SerializeField] private int maxValue = 0;

    private Slider _slider; 
    void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = 100;
        _slider.minValue = 0;
        float level;
        if (PlayerPrefs.HasKey(groupID))
        {
            level = PlayerPrefs.GetFloat(groupID);
            _slider.value = level;
            ChangeVolume(level);
        }
        else
        {
            mixer.GetFloat(groupID, out float t);
            _slider.value = Mathf.Lerp(0, 100, (t - minValue) / (maxValue - minValue));
        }
        
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float v)
    {
        mixer.SetFloat(groupID, Mathf.Lerp(minValue, maxValue, v/100));
        PlayerPrefs.SetFloat(groupID , v);
    }
}
