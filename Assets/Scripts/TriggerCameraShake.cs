using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraShake : MonoBehaviour
{
    public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }

    void ShakeCameraForAttack() {
        StartCoroutine(cameraShake.Shake(0.10f, 0.2f));
    }

    void ShakeCameraForDamage() {
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }

    void ShakeCameraForEgg() {
        StartCoroutine(cameraShake.Shake(0.05f, 0.1f));
    }
}
