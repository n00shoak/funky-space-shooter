using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_SwarmerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player, TargetPoint;
    [SerializeField] private SY_AImovement movement;
    [SerializeField] private float variation;

    void Start()
    {
        TargetPoint = Instantiate(TargetPoint, transform);
        movement.targetPos = TargetPoint;
        movement = GetComponent<SY_AImovement>();
        player = GameObject.Find("Player");
        variation = Random.Range(0.5f, 2f);
    }

    void Update()
    {
        TargetPoint.transform.position = player.transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) < 15)
        {
            movement.maxSpeed = 1200;
            movement.rotationSpeed = variation;
        }
        else
        {
            movement.maxSpeed = 1000;
            movement.rotationSpeed = 20f;

        }
    }
}
