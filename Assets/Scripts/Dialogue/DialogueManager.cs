using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dilaogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    //dialogue is playing can only be read not changed
    public bool dialogueIsPlaying { get; private set; }

    #region "Singleton"
    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found!");
        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    #endregion

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //return if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //handle continue to next line in dialogue when interact is pressed
        if (Input.GetButtonUp("Continue"))
        {
            ContinueStory();
        }
    }

    public void EntryDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);
        dialogueIsPlaying = true;

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.5f);

        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        dialogueIsPlaying = false;
    }

    //typing Effect
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust speed
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            StopAllCoroutines();

            //set text for current dialogue 
            StartCoroutine(TypeSentence(currentStory.Continue()));
            
            //display choices if there are any
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        //defensive check to make sure there are no more choices than UI elements
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogWarning("There are more choices than UI elements");
        }

        int index = 0;
        //enable and initialize the choices UI elements
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //go through the remaining UI elements and disable them
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    private IEnumerator SelectFirstChoice()
    {
        //event system requires we clear it first, then wait
        //for atleast one frame before setting the selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
}

