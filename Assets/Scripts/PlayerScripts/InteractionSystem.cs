using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;

public class InteractionSystem : MonoBehaviour
{
    private int interactionLayer = 1 << 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D interactCollider = Physics2D.OverlapCircle(transform.position, 1.5f, interactionLayer);
            if (interactCollider != null)
            {
                if (interactCollider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact(gameObject);
                }
            }
        }
            
    }
}
