using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is responsinle for outputing appropriate text when a player is nearby interactable thing
public class BaseInteraction : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager; //"Press E to..." object

    [SerializeField] private string _preInteractionString = "Нажмите 'E', чтобы спрятаться";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //check for player tag to avoid triggers to other entities
        {
            _uiManager.interactionText.SetActive(true);
            _uiManager.interactionText.GetComponent<Text>().text = _preInteractionString;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _uiManager.interactionText.SetActive(false);
    }
}
