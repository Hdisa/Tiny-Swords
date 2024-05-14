using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Worker;
    
    void Start()
    {
        if(transform.childCount > 0) return;
        Instantiate(Worker, transform);
    }

}
