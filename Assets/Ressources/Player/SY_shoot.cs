using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject bulletHolder;
    [SerializeField] private float attSpeed;
    [SerializeField] bool coolDown = true;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1) && coolDown == true)
        {
            StartCoroutine(CoolDownTimer());
            GameObject bullet = Instantiate(projectile, transform);
            bullet.transform.parent = bulletHolder.transform;

            //bullet have the same velocity has the player
            Rigidbody playerRB = GetComponent<Rigidbody>();
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = playerRB.velocity;
        }
    }

    IEnumerator CoolDownTimer()
    {
        coolDown = false;
        yield return new WaitForSeconds(attSpeed);
        coolDown = true;
    }
}
