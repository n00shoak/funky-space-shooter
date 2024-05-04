using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_ShipRotation : MonoBehaviour
{
    [SerializeField] private MN_Player manager;
    void Update()
    {
        // get cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();

            // get rotation towards cursor
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // create rotation angle
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

            // progressive rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, manager.playerStats.MovementStats[3] * Time.deltaTime);
        }
    }
}
