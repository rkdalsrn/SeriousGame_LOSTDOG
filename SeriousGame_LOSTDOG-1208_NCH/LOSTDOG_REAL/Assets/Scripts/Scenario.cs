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
    /*
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
    */

    public GameObject nextButton;

    void Start()
    {
        StartCoroutine("LoadSceneAfterTransition");
    }

    public void Next_Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator LoadSceneAfterTransition()
    {
        yield return new WaitForSeconds(3f);
        nextButton.SetActive(true);
    }
}
