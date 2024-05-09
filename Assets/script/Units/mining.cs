using System;
using UnityEngine;

public class mining : MonoBehaviour
{

    public bool maning;

    private hp_resurs resurs;

    private void Start()
    {
        resurs = GetComponent<hp_resurs>();
    }

    private void Update()
    {
        if (maning)
        {
            resurs.hp -= 1 * Time.deltaTime / 2;
        }

        maning = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (resurs != null)
        {
            maning = true;
        }
    }
}
