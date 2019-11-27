using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Scenario는 Scene에 들어가야 함.
 * 이 Script는 Scene의 Child에 있는 scene들을 받아와서
 * 스토리를 보여주는 역할을 한다.
 */

public class Scenario : MonoBehaviour
{
    public int numberOfScene;
    public GameObject[] scene;
    public GameObject fadePanel;
    public GameObject chapterPanel;

    public int isActive;
    Animator animOfFadePanel;
    Animator animOfChapterPanel;

    void Awake()
    {
        numberOfScene = transform.childCount;
        scene = new GameObject[numberOfScene];
        for(int n = 0; n < numberOfScene; n++)
        {
            scene[n] = GameObject.Find(n.ToString());
            scene[n].SetActive(false);
        }
        fadePanel.SetActive(true);
        chapterPanel.SetActive(true);
        isActive = 0;
        animOfChapterPanel = chapterPanel.GetComponent<Animator>();
        animOfFadePanel = fadePanel.GetComponent<Animator>();
    }

    public void OnButtonClick()
    {
        NextScene();
    }

    void NextScene()
    {
        if (isActive == numberOfScene)
        {
            StartCoroutine(LoadSceneAfterTransition());
        }
        else
        {
            for (int n = 0; n < numberOfScene; n++)
            {
                scene[n].SetActive(false);
            }
            scene[isActive].SetActive(true);
            isActive++;
        }
        return;     
    }

    private IEnumerator LoadSceneAfterTransition()
    {
        animOfFadePanel.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
