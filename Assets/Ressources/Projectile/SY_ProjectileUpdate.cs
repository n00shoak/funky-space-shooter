using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(SY_ProjectileUpdate))]
public class SY_ProjectileUpdate : MonoBehaviour
{
    public UnityEvent toUpdate;

    public void ManualUpdate()
    {
        toUpdate.Invoke();
    }
}
