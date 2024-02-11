using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/*A singleton that contains all UI references*/
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [HideInInspector] public GameObject canvas { get; private set; }
    [HideInInspector] public GameObject interactionText { get; set; }
    [HideInInspector] public GameObject gameOverFrame { get; set; }

    [HideInInspector] public GameObject dialogueBox { get; set; }
    [HideInInspector] public GameObject dialogueText { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        /*get all UI references*/
        canvas = GameObject.Find("Canvas");
        interactionText = GameObject.Find("InteractionText");
        gameOverFrame = GameObject.Find("GameOverFrame");
        dialogueBox = GameObject.Find("DialogueBox");
        dialogueText = GameObject.Find("DialogueText");

        /*Unity can't find inactive objects, so when Awake function works, some UI elements need to be active.
         So there are some UI elements, that should be disabled by default*/
        interactionText.SetActive(false);
        gameOverFrame.SetActive(false);
        dialogueBox.SetActive(false);

        DontDestroyOnLoad(gameObject);
    }

}
