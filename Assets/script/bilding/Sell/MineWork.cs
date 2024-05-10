using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWork : MonoBehaviour
{

    public sell Sell;

    public float plys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sell.Sell += (1 * plys) * Time.deltaTime;
    }
}
