using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using PlayerScripts;

public class DoorNextLevel : MonoBehaviour, IInteractable
{

    private LevelLoader _levelLoader;
    public void Interact(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement component))
        {
            component.disableControls();
        }
        
        _levelLoader.LoadNextLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        _levelLoader = GetComponent<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
