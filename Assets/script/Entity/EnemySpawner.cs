using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeToSpawn;
    private float timer;

    private void Start()
    {
        timer = timeToSpawn;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Instantiate(enemyPrefab, transform);
            timer = timeToSpawn;
        }
    }
}
