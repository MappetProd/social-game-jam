using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePlace : MonoBehaviour
{
    private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerStates state = gameObject.GetComponent<PlayerStates>();
                PlayerMovement movementController = gameObject.GetComponent<PlayerMovement>();
                SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

                if (state.isHiding)
                {
                    sr.enabled = false;
                    movementController.disableControls();
                }
                else
                {
                    sr.enabled = false;
                    movementController.disableControls();
                }
            }
        }
    }

    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
