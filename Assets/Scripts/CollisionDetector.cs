using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public Dialogue dialogueBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.tag);

        if(collision.tag == "Player" && dialogueBox.hasRead == false)
        {
            dialogueBox.StartDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.tag);

        if (collision.tag == "Player" && dialogueBox.hasRead == false)
        {
            dialogueBox.StopDialog();
        }
    }
}
