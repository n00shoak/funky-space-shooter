using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ship stats", menuName = "ship stats", order = 0)]
public class SO_ShipData : ScriptableObject
{
    [Header(" === Movemments Stats ===")]
    [SerializeField] private float[] MovementStats = new float[4];
    /*
    0 = max speed
    1 = accel
    2 = friction
    3 = rotation speed
    */

    [Header(" === base Health Stats === ")]
    [SerializeField] private float[] healthStats = new float[8];
    /*
    0 = hp
    1 = hp regen
    2 = timer before hp regen
    3 = hp armor
    4 = shield ammount 
    5 = shield armor 
    6 = shield regen
    7 = timer before shield regen
    */

    [Header(" === base Attack Stats === ")]
    [SerializeField] private float[] attackStats = new float[6];
    /*
    0 = damage
    1 = multishot
    2 = attack speed
    3 = projectile velocity
    4 = projectile size
    5 = attack range
    */

    public void SetMovement(int which = 0, float value = 0)
    {
        MovementStats[which] = value;
    }

    public void SetAllMovement(float[] values)
    {
        MovementStats = values;
    }

    public void SetHeatlh(int which = 0, float value = 0)
    {
        attackStats[which] = value;
    }

    public void SetAllHeatlh(float[] values)
    {
        attackStats = values;
    }

    public void SetAttacks(int which = 0, float value = 0)
    {
        healthStats[which] = value;
    }

    public void SetAllAttacks(float[] values)
    {
        healthStats = values;
    }
}

