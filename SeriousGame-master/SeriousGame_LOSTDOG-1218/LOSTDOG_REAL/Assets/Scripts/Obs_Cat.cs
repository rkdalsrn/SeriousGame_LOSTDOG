using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* CatRule은 고양이 장애물의 기믹이다.
 * dog를 넣어줘야한다.
 */

public class Obs_Cat : MonoBehaviour
{
    public GameObject dog;
    public GameObject gamePanel;
    public AudioSource cataudio;
    public AudioClip jumSound;
    int isMoving;
    int isComing;
    float isClicked;
    public bool isfailed = false;
    public Vector3 startPoint;
    bool firstTime;

    Animator anim;
    Animator dogAnim;
    GameObject rayScript;


    void Start()
    {
        anim = GetComponent<Animator>();
        dog = GameObject.Find("Dog");
        gamePanel = GameObject.Find("GamePanel");
        isComing = 0;
        dogAnim = dog.GetComponent<Animator>();
        this.cataudio = this.gameObject.AddComponent<AudioSource>();
        this.cataudio.clip = this.jumSound;
        this.cataudio.loop = false;
        this.cataudio.volume = 1.0f;
        firstTime = true;
    }

    void FixedUpdate()
    {
        CatFunction();
        SetAnim();
    }

    void CatFunction()
    {
        startPoint = dog.GetComponent<RayScript>().startPoint;
        isMoving = dog.GetComponent<RayScript>().isMoving;
        isClicked = gamePanel.GetComponent<GamePanel>().isClicked;
        if (isMoving == 0 && dog.transform.position == transform.position)
        {
            if (firstTime)
            {
                this.cataudio.Play();
                firstTime = false;
            }
            isfailed = true;
            print("Fail!");     //debug    
            StartCoroutine("GameOver");
        }
        else isfailed = false;
    }

    IEnumerator GameOver()
    {
        for (int n = 0; n < 6; n++)
        {
            dog.GetComponent<RayScript>().mingu[n].SetActive(false);
        }
        isComing = 1;
        yield return new WaitForSeconds(1f);
        dog.GetComponent<Animator>().SetFloat("isFailed", 1);
        yield return new WaitForSeconds(2f);
        gamePanel.GetComponent<Animator>().SetFloat("isPanelButtonClicked", 1);

    }


    void SetAnim()
    {
        anim.SetFloat("isComing", isComing);
        
    }
}
