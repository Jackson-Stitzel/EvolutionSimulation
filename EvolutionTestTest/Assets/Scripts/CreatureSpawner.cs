using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    int numSpawn = 0;
    [SerializeField]
    Transform Prefab = null;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numSpawn; i++){
            Instantiate(Prefab, Prefab.transform.position, Quaternion.identity);
        }
    }
}
