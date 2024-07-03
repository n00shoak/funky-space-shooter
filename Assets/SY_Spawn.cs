using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SY_Spawn : MonoBehaviour
{
    public GameObject toSpawn;
    [SerializeField] private int ammoutMin, ammoutMax;
    
    void Start()
    {
        for(int i = 0; i < Random.Range(ammoutMin, ammoutMax); i++)
        {
            GameObject instance = Instantiate(toSpawn);
            instance.transform.parent = null;
            instance.transform.position = transform.position;
        }
    }
}
