using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_AImovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float maxSpeed, accel, friction,rotationSpeed;
    [SerializeField] public GameObject targetPos;
    [SerializeField] public bool canMove = true, canRotate = true;

    public void move()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward.normalized * accel);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.5f * Time.deltaTime);// limit speed
        }
    }

    private void rotation()
    {
        Vector3 direction = targetPos.transform.position - transform.position;
        direction.Normalize();

        // get rotation towards cursor
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // create rotation angle
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

        // progressive rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        // friction;
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, friction * Time.deltaTime);   // drag

        if (canRotate) {rotation(); }
        if (canMove) { move(); }
        
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(hit.point, 0.25f);
        }
    }
}
