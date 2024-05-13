using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_SpawnEnnemis : MonoBehaviour
{
    [SerializeField] private Transform palyer;
    [SerializeField] private float spawnRadiusMin, spawnRadiusMax;
    [SerializeField] private GameObject[] tospawn;

    void Start()
    {
        StartCoroutine(spawnStuff());
    }

    IEnumerator spawnStuff()
    {
        // get position
        float angle = Random.Range(0f, Mathf.PI * 2);
        float radius = Random.Range(spawnRadiusMin, spawnRadiusMax);

        float x = palyer.position.x + Mathf.Cos(angle) * radius;
        float y = palyer.position.y + Mathf.Sin(angle) * radius;

        GameObject stuff = Instantiate(tospawn[Random.Range(0, tospawn.Length)], new Vector3(x, 0, y), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        stuff.transform.parent = null;
        yield return new WaitForSeconds(10);
        StartCoroutine(spawnStuff());
    }
}
