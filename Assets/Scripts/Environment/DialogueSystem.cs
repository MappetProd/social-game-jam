using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private string[] lines;

    [SerializeField]
    private float textSpeed;

    [SerializeField]
    private UIManager _uiManager;

    private Text textComponent;

    private int _index;

    [HideInInspector]
    public bool isStarted = false;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        textComponent = _uiManager.dialogueText.GetComponent<Text>();
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (isStarted)
        {
            _uiManager.interactionText.SetActive(false);
        }

        if (Vector2.Distance(_player.transform.position, transform.position) > 3f) {
            StopDialogue();
        }
    }

    public void StartDialogue()
    {
        _index = 0;
        isStarted = true;
        _uiManager.dialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void HandleMouseClick()
    {
        if (isStarted)
        {
            if (textComponent.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[_index];
            }
        }
    }

    public void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StopDialogue();
        }
    }

    private void StopDialogue()
    {
        textComponent.text = string.Empty;
        StopAllCoroutines();
        isStarted = false;
        _uiManager.dialogueBox.SetActive(false);
    }
}
