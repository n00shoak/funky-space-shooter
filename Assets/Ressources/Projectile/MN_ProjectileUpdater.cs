using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MN_ProjectileUpdater : CL_Manager
{
    private SY_ProjectileUpdate[] allProjectile;

    void Update()
    {
        allProjectile = GetComponentsInChildren<SY_ProjectileUpdate>();
        for(int i = 0; i < allProjectile.Length; i++)
        {
            allProjectile[i].ManualUpdate();
        }
    }
}
