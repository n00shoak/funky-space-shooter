using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MN_Player : CL_Manager
{
    [SerializeField] public DT_Ship playerStats;
    [SerializeField] public SY_ShipMovement plMovement;
    [SerializeField] public KeyCode
    forward = KeyCode.Mouse0,
    shoot = KeyCode.Mouse1,
    spellA = KeyCode.Mouse2,
    spellB = KeyCode.Mouse3,
    spellC = KeyCode.Mouse4;

    private void Update()
    {
        if(Input.GetKey(forward)) 
        {
            plMovement.move();
        }
    }

}
