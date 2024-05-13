using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SY_ScreenShake : MonoBehaviour
{

    private Camera _cam;
    void Start()
    {
        _cam = Camera.main;
        StartCoroutine(CameraShake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CameraShake(float duration =1, float power = 2.5f)
    {
        var originPos = _cam.transform.position;
        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            _cam.transform.position = originPos + Random.insideUnitSphere * power;
            yield return new WaitForEndOfFrame();
        }

        _cam.transform.position = originPos;
    }
}
