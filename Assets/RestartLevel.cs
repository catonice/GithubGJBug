using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public string action = "Restart";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (action == "Restart")
            {
                SceneManager.LoadScene("PPLevel1"); //Load scene called Game
            }
            else if(action == "Quit")
            {
                Application.Quit();
            }
        }
    }
}