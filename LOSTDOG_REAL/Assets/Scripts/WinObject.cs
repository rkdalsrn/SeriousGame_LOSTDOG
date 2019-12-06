using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinObject : MonoBehaviour
{
    Animator anim;    
    Animator animatorOfPanel;  

    public GameObject fadePanel;
    public GameObject dog; 
    Vector3 dogLocation;

    int isMoving;               //강아지가 움직이는지 받아올 변수
    public float isWin;                 // 승리 조건
    
    void Awake()
    {
        fadePanel = GameObject.Find("Canvas").transform.Find("FadePanel").gameObject;
        dog = GameObject.Find("Dog");
        anim = GetComponent<Animator>();
        animatorOfPanel = fadePanel.GetComponent<Animator>(); 
        fadePanel.SetActive(true);

        isWin = 0;   
        isMoving = dog.GetComponent<RayScript>().isMoving;   
    }

    void Update()
    {
        CheckWin();
        SetAnimation();
    }

    //승리여부 확인
    void CheckWin()
    {
        if (isMoving == 0)
        {
            dogLocation = dog.transform.position;   // 강아지 위치 받아오기
            if (dogLocation == transform.position)  // 같은지 확인해서 같으면 winning animation 활성화
            {
                isWin = 1;
                isMoving = 1;
                StartCoroutine(LoadSceneAfterTransition());
            }
                
        }
    }

    //씬 전환 코루틴
    private IEnumerator LoadSceneAfterTransition()
    {
        //show animate out animation
        yield return new WaitForSeconds(5f);
        animatorOfPanel.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);
        
        //프로토타입 전용 코드. 끝나면 종료
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            Application.Quit();
            print("QUIT");
        }
        else
        {
            print("Next Scene is" + SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Animator 설정
    void SetAnimation()
    {
        anim.SetFloat("isWin", isWin);     //isWin 변수에 isWin 값 집어넣기
    }
}
