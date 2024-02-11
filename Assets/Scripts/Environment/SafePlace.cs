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
        private AudioManager _audioManager;

        private const string HIDE_INTERACTION_STRING = "Press 'E' to hide";
        private const string CONTINUE_INTERACTION_STRING = "Press 'E' to get out of a shelter";

        private void Awake()
        {
            _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        public void Interact(GameObject playerObject)
        {
            PlayerStates states = playerObject.GetComponent<PlayerStates>();
            PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
            SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();

            states.isHiding = !states.isHiding;
            _audioManager.PlaySFX(_audioManager.hide);
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