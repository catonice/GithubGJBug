using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject textDisplayPanel;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public TextMeshProUGUI continuePrompt;
    public GameObject continuePromptPanel;
    public AudioClip voice;
    public GameObject player;

    public bool hasRead = false;

    private void Start()
    {
    }

    public void StartDialog()
    {
        textDisplayPanel.SetActive(true);
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continuePrompt.enabled = true;
            continuePromptPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                 NextSentence();
            }
        }
    }

    IEnumerator Type() { 
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            SoundManager.instance.PlaySoundWithRandomPitch(voice);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {

        continuePrompt.enabled = false;
        continuePromptPanel.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            textDisplay.enabled = false;
            textDisplayPanel.SetActive(false);
            hasRead = true;
        }
    }
}
