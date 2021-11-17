using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyDown : MonoBehaviour
{
    public LevelChanger lvlChanger;

    // Detects if any key has been pressed.
    void Update()
    {
        if (Input.anyKey)
        {
            PlayGame();
        }
    }
    public void PlayGame()
    {
        lvlChanger.FadeToNextLevel();
    }
}
