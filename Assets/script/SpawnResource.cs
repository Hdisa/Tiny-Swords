using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnResource : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float respawnTime = 5;

    private float timer;

    private void Start()
    {
        if(gameObject.TryGetComponent(out SpriteRenderer sr))
             sr.enabled = false;
        if (transform.childCount > 0) return;
        Instantiate(prefab, transform);
        timer = respawnTime;
    }

    private void Update()
    {
        if (transform.childCount > 0) return;
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        Instantiate(prefab, transform);
        timer = respawnTime;
    }
}
