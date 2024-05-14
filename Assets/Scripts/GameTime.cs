using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float GameSecond;
    public float GameHour;

    string stringSecond;
    private string stringHour;

    public TextMeshProUGUI textTime;

    void Update()
    {
        GameSecond += Time.deltaTime;

        stringSecond = GameSecond.ToString();
        stringHour = GameHour.ToString();

        textTime.text = stringHour + ":00";

        if (GameSecond >= 30.0f)
        {
            GameHour = GameHour + 1;
            GameSecond = 0;
        }

        if(GameHour >= 24)
        {
            GameHour = 00;
        }
    }
}
