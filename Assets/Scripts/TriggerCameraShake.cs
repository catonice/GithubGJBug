using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraShake : MonoBehaviour
{
    public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }
}
