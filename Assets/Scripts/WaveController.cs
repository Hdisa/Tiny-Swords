using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawners;
    private int wave;
    
    private void Update()
    {
        //С каждым часом, врагов будет спавниться всё больше
        for (int i = 0; i < GameTime.GameHour; i++) spawners[i].SetActive(true);
    }
}
