using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
public class BoatMan : MonoBehaviour, IInteractable
{

    private DialogueSystem _dialogueSystem;
    void Start()
    {
        _dialogueSystem = GetComponent<DialogueSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dialogueSystem.HandleMouseClick();
        }
    }

    public void Interact(GameObject gameObject)
    {
        _dialogueSystem.StartDialogue();
    }
}
