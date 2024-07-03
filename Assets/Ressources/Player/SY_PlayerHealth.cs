using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SY_Playerealth : MonoBehaviour
{
    [SerializeField] private Slider[] healthSlider, damageIndic;
    [SerializeField] private float healthSmoothness, curentHealth;
    private DT_Ship shipData;


    private void Awake()
    {
        shipData = GetComponent<DT_Ship>();
    }

    private void Update()
    {
        // update Health Bar;
        curentHealth = Mathf.Clamp(curentHealth, 0, shipData.healthStats[0]);

        healthSlider[0].value = Mathf.Lerp(healthSlider[0].value, curentHealth / shipData.healthStats[0], Time.deltaTime * healthSmoothness);
        healthSlider[1].value = Mathf.Lerp(healthSlider[1].value, curentHealth / shipData.healthStats[0], Time.deltaTime * healthSmoothness);

        damageIndic[0].value = Mathf.Lerp(damageIndic[0].value, curentHealth / shipData.healthStats[0], Time.deltaTime * (healthSmoothness + (damageIndic[0].value < healthSlider[0].value ? 10 : -2)));
        damageIndic[1].value = Mathf.Lerp(damageIndic[1].value, curentHealth / shipData.healthStats[0], Time.deltaTime * (healthSmoothness + (damageIndic[1].value < healthSlider[1].value ? 10 : -2)));

    }
}
