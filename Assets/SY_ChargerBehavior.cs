using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_ChargerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject TargetPoint,playerPosition;
    [SerializeField] private float ramDistance;
    [SerializeField] private SY_AImovement movement;
    [SerializeField] private ParticleSystem booster;
    private float coolDown;

    private void Start()
    {
        TargetPoint = Instantiate(TargetPoint, transform);
        movement = GetComponent<SY_AImovement>();
        playerPosition = GameObject.Find("Player");

        movement.targetPos = TargetPoint;
    }

    private void Update()
    {
        TargetPoint.transform.position = playerPosition.transform.position;
        if (Vector3.Distance(transform.position, playerPosition.transform.position)< ramDistance) // ram State
        {

            if (coolDown <= 0)
            {
                StartCoroutine(CoolDown());
                StartCoroutine(Charge());
                coolDown = 5;
            }
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        coolDown--;
        if(coolDown > 0)
        {
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator Charge()
    {
        float speed = movement.maxSpeed;
        float friction = movement.friction;
        float rotation = movement.rotationSpeed;
        float acceleration = movement.accel;

        // targetig player
        movement.maxSpeed = 0;
        movement.friction = 10;
        movement.rotationSpeed = 20;

        // sprint
        yield return new WaitForSeconds(1);
        booster.Play();
        movement.maxSpeed = 300;
        movement.friction = 2;
        movement.rotationSpeed = 0;
        movement.accel = 300;

        // stop
        yield return new WaitForSeconds(0.5f);
        movement.friction = 100;

        // back to normal
        yield return new WaitForSeconds(0.25f);
        movement.maxSpeed = speed;
        movement.friction = friction;
        movement.rotationSpeed = rotation;
        movement.accel = acceleration;
    }
}
