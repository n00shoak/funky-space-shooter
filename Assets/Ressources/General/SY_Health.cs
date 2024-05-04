using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_Health : MonoBehaviour
{
    [SerializeField] private float health,armor;
    [SerializeField] GameObject deathEffetct;

    public float getHealth()
    {
        return health;  
    }

    public void setHealth(float ammount = 1)
    {
        health = ammount;

        if (health <= 0)
        {
            death();
        }
    }

    public void TakeDamage(float damage = 1)
    {
        health -= Mathf.Lerp(damage, 1, 100 / armor);
        Debug.Log("damage took : " + Mathf.Lerp(damage, 1, 100 / armor));

        if(health <=0)
        {
            death();
        }
    }

    private void death()
    {
        if (deathEffetct != null)
        {
            GameObject deathEff = Instantiate(deathEffetct);
            deathEff.transform.parent = null;
            deathEff.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

}
