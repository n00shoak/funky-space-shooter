using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_experiencePoint : MonoBehaviour
{
    [SerializeField] private float value = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.position += new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));

        if (value > 5) transform.localScale *= 1.25f;
        if (value > 25) transform.localScale *= 1.5f;
        if (value > 50) transform.localScale *= 2f;

        player = GameObject.Find("Player");


        StartCoroutine(goToPlayer());
        rb.angularVelocity = Random.insideUnitSphere * 30f;
    }

    private IEnumerator goToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.05f);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(goToPlayer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        DT_Player playerData = collision.gameObject.GetComponent<DT_Player>();
        if(playerData != null ) { playerData.xp += value; }
        Destroy(gameObject);
    }
}
