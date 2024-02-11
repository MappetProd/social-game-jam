using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public class SafePlace : MonoBehaviour, IInteractable
    {

        [SerializeField] 
        private UIManager _uiManager;

        private const string HIDE_INTERACTION_STRING = "Нажмите 'E', чтобы спрятаться";
        private const string CONTINUE_INTERACTION_STRING = "Нажмите 'E', чтобы выйти из склепа";
        public void Interact(GameObject playerObject)
        {
            PlayerStates states = playerObject.GetComponent<PlayerStates>();
            PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
            SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();

            states.isHiding = !states.isHiding;
            
            if (states.isHiding)
            {
                playerMovement.disableControls();
                spriteRenderer.enabled = false;
                _uiManager.interactionText.GetComponent<Text>().text = CONTINUE_INTERACTION_STRING;
            }
            else
            {
                playerMovement.enableControls();
                spriteRenderer.enabled = true;
                _uiManager.interactionText.GetComponent<Text>().text = HIDE_INTERACTION_STRING;
            }
        }
    }
}