using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class SafePlace : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject playerObject)
        {
            PlayerStates states = playerObject.GetComponent<PlayerStates>();
            PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
            SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();

            states.isHiding = !states.isHiding;
            
            if (states.isHiding)
            {
                playerMovement.enableControls();
                spriteRenderer.enabled = true;
            }
            else
            {
                playerMovement.disableControls();
                spriteRenderer.enabled = false;
            }
        }
    }
}