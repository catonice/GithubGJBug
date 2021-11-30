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

    public float fromPitch = 0.9f; 
    public float toPitch = 1f; 

    public bool hasRead = false;
    public bool leftZone = false;

    private void Start()
    {
    }

    public void StartDialog()
    {
        if (leftZone)
        {
            textDisplay.text = "";
            leftZone = false;
        }
        textDisplayPanel.SetActive(true);
        StartCoroutine(Type());
    }

    public void StopDialog()
    {
        leftZone = true;
        textDisplay.text = "";
        textDisplayPanel.SetActive(false);
        StopCoroutine(Type());
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
            SoundManager.instance.PlaySoundWithRandomPitch(voice, fromPitch, toPitch);
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
