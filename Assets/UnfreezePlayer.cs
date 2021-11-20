using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezePlayer : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public GameObject playerCanvas;
    // Start is called before the first frame update
    void UnfreezeRigidbody() {
        playerRigidbody.constraints = RigidbodyConstraints2D.None;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerCanvas.SetActive(true);
    }
}
