using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;

public class DoorNextLevel : MonoBehaviour, IInteractable
{

    private LevelLoader _levelLoader;
    public void Interact(GameObject gameObject)
    {
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
