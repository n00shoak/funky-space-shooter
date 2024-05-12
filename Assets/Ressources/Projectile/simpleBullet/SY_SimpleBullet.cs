using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_SimpleBullet : MonoBehaviour
{
    
    private Rigidbody rb;
    private float maxLifettime, currentLifeTime;
    [SerializeField] private GameObject deathfx;
    
    private void Awake()
    {
        maxLifettime = MN_GeneralManager.GetManagerfromGeneral<MN_Player>().playerStats.attackStats[5] + 1;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(lifeTime());
        Debug.Log("TEST" +  rb.velocity);
    }
    

    public void ManualUpdate()
    {

        rb.velocity += transform.forward * 5f;


        if (currentLifeTime >= maxLifettime)
        {
            destroyed();
        }

        // scale by time :
        //transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, currentLifeTime / maxLifettime );
    }
    
    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(0.1f);
        currentLifeTime += 1;
        StartCoroutine(lifeTime());
    }
    
    public void destroyed()
    {
        GameObject fx = Instantiate(deathfx);
        fx.transform.parent = null;
        fx.transform.position = transform.position;
        Debug.Log("OUI");
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<SY_Health>().TakeDamage();

        destroyed();
    }
    
}
