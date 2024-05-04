using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_LifeTime : MonoBehaviour
{
    public float lifeTime = 1;
    
    void Start()
    {
        StartCoroutine(countDown());
    }

    // final countdown
    IEnumerator countDown()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
