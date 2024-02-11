using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    [SerializeField]
    private bool isCutscene;

    // Start is called before the first frame update
    void Start()
    {
        if (isCutscene)
        {
            LoadNextLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevel(nextSceneIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //animator.SetTrigger("End");
        if (isCutscene)
        {
            yield return new WaitForSeconds(transitionTime);
        }
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
