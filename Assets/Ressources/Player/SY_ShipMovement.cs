using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_ShipMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MN_Player manager;

    public Camera mainCamera;

    public KeyCode lockDir;
    // public KeyCode strafeLeft;
    // public KeyCode strafeRight;

    public void move()
    {
        if (rb.velocity.magnitude < manager.playerStats.MovementStats[0])
        {
            rb.AddForce(transform.forward.normalized * manager.playerStats.MovementStats[1]);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.5f * Time.deltaTime);// limit speed
        }
    }

    void Update()
    {
        // friction;
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, manager.playerStats.MovementStats[2] * Time.deltaTime);   // drag
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
