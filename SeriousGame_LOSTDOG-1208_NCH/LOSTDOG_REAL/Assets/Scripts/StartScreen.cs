using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/* StartScreen은 Fade Image에 들어가 있어야한다.
 * 버튼의 트리거로도 사용된다
 */

public class StartScreen : MonoBehaviour
{
    public GameObject panel1;
    Animator animator;

    void Awake()
    {
        animator = transform.GetComponent<Animator>();      //animator 받아오기
        panel1.SetActive(true);
    }

    public void StartClick()
    {
        StartCoroutine(LoadSceneAfterTransition());
    }

    //씬 전환 코루틴
    private IEnumerator LoadSceneAfterTransition()
    {
        //show animate out animation
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);
        //load the scene we want
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ExitClick()
    {
        print("QUIT");
        Application.Quit();
    }
}