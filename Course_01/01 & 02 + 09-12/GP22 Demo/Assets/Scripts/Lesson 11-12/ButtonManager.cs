using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject[] dialogueTextBoxes;
    int rowsOfDialogue;
    int currentRowOfDialogue;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rowsOfDialogue = dialogueTextBoxes.Length;
        for (int i = 0; i < rowsOfDialogue; i++)
        {
            dialogueTextBoxes[i].SetActive(false);
        }
        currentRowOfDialogue = 0;
        dialogueTextBoxes[currentRowOfDialogue].SetActive(true);
    }

    public void Continue()
    {
        if (currentRowOfDialogue < rowsOfDialogue - 1)
        {
            audioSource.Play();
            currentRowOfDialogue++;
            dialogueTextBoxes[currentRowOfDialogue].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
