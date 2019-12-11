﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Dog에 들어갈 Script
 * WindObject, Fade Panel을 정해주어야 한다.
 */
public class RayScript : MonoBehaviour
{
    public Vector3 startPoint;  //시작점 위치
    public Vector3 firstPos;           //멍멍이 처음 위치
    Vector3 dogScale;           //멍멍이 스케일
    public Vector3 pos;         //도착할 곳
    public Vector3 undopos;         //전에 도착했더 곳
    RaycastHit2D hit;           //Ray가 닿은 GameObject
    public Vector3[] directionOfDog = { new Vector3(0.5f, 0.75f, 0), new Vector3(1f, 0, 0), new Vector3(0.5f, -0.75f, 0),
                                    new Vector3(-0.5f, -0.75f, 0), new Vector3(-1f, 0, 0), new Vector3(-0.5f, 0.75f, 0) };
    public float distance;
    public float moveSpeed;

    public int isMoving = 0;    //움직이는 여부 테스트. 움직이는 도중의 키입력 예방.
    public int isFlip = 0;             //뒤집힘 여부. 왼쪽 보고 있는게 0일때.
    float isWin = 0;            //WinObject에서 받아올 isWin

    Animator anim;              // 애니메이션 설정 변수

    public GameObject winObject;           // 목표점 받아오기
    public GameObject chapterPanel;        // 패널 받아오기
    public GameObject undo;

    RaycastHit2D hitOfButton;

    public int[] buttonNum = new int[6];
    public GameObject[] mingu = new GameObject[6];
    int chanceCount = 0;

    public int currentTry = 0;     //현재 시도 횟수
    public int maxTry = 3;    //최대 시도 횟수

    void Start()
    {
        InitDog();
        InitUI();
        buttonUI();
    }

    void FixedUpdate()
    {
        IsMax();
        buttonUI();
        MakeDogMove();
        SetAnimation();
        IsWin();
    }

    //초기 설정
    void InitDog()
    {
        anim = GetComponent<Animator>();
        winObject = GameObject.Find("WinObject");
        undo = GameObject.Find("undo");
        chapterPanel = GameObject.Find("Canvas").transform.Find("ChapterPanel").gameObject;
        firstPos = transform.position;  
        dogScale = transform.localScale;    
        pos = new Vector3(0, 0, 10.0f);  
        startPoint = firstPos;

        for (int n = 0; n < 6; n++)
        {
            mingu[n] = GameObject.Find((n + 1).ToString()).gameObject;
        }
    }

    void InitUI()
    {
        chapterPanel.SetActive(true);
    }

    // 이동할 수 있는 버튼 표시 및 이동 UI
    void buttonUI()
    {
        if (isMoving == 1)
        {
            for(int n =0; n < mingu.Length; n++)
            {
                mingu[n].SetActive(false);
            }
        }
        else
        {
            for(int n = 0; n < mingu.Length; n++)
            {
                int layerMaskOfButton = 1 << LayerMask.NameToLayer("Wall");
                hitOfButton = Physics2D.Raycast(transform.position, directionOfDog[n], 10f, layerMaskOfButton);
                if ((hitOfButton.transform.position - directionOfDog[n]) == transform.position)
                    mingu[n].SetActive(false);
                else mingu[n].SetActive(true);
            }
        }
    }

    // 강아지가 움직이는 메카닉.
    void MakeDogMove()
    {
        for(int n = 0 ; n < buttonNum.Length ; n++)
        {
            if (isMoving == 0 && buttonNum[n] != 0)
            {
                undo.GetComponent<undoScript>().mingu = 0;
                undopos = firstPos;
                isMoving = 1;
                if (n < 3)
                    isFlip = 1;
                else isFlip = 0;
                if (buttonNum[n] == 1)
                {
                    int layerMask = 1 << LayerMask.NameToLayer("Wall");
                    hit = Physics2D.Raycast(transform.position, directionOfDog[n], 10f, layerMask);
                    if (hit.collider != null)
                    {
                        float distance = Mathf.Sqrt((hit.transform.position.x - transform.position.x) * (hit.transform.position.x - transform.position.x)
                            + (hit.transform.position.y - transform.position.y) * (hit.transform.position.y - transform.position.y));

                        pos = hit.transform.position - directionOfDog[n];
                    }
                }
            }
            
        }
        //  최종 이동

        if (pos != new Vector3(0,0,10.0f) && undo.GetComponent<undoScript>().mingu == 0)
        {
            FlipDog(isFlip); 
            moveSpeed = Time.deltaTime * 2.0f;   
            if (transform.position != pos)
                chanceCount = chanceCount + 1;
            transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed); 
            if (transform.position == pos && isMoving != 0)     //도착했을 때 실행되는 부분
            {
                currentTry = currentTry + 1;
                for (int n = 0; n< buttonNum.Length ;n++)
                    buttonNum[n] = 0;
                firstPos = transform.position;  //도착 위치를 다음 이동시의 firstPos로 설정
                isMoving = 0;      //이동이 끝나야 다시 키 받아올 수 있음
            }
        }
    }

    //강아지 뒤집기
    void FlipDog(int isFlip)
    {
        float x = dogScale.x;
        if (x < 0) x = -x;
        if (isFlip == 0)
            dogScale.x = x;    
        else dogScale.x = -x;
        transform.localScale = dogScale;
    }

    //Animator 설정
    void SetAnimation() 
    {
        anim.SetFloat("speed", isMoving);    
        anim.SetFloat("isWin", isWin);    
    }

    void IsWin()
    {
        isWin = winObject.GetComponent<WinObject>().isWin;
        if (isWin == 1)
            for(int n = 0; n < mingu.Length; n++)
                mingu[n].SetActive(false);
    }

    void IsMax()
    {
        if (currentTry > maxTry)
        {
            StartCoroutine(FailedByCount());
        }
    }

    private IEnumerator FailedByCount()
    {
        print("Failed by Count!!");

        for (int n = 0; n < mingu.Length; n++)
            mingu[n].SetActive(false);
        anim.SetFloat("isFailed", 1);
        yield return new WaitForSeconds(1f);
        GameObject.Find("GamePanel").GetComponent<Animator>().SetFloat("isPanelButtonClicked",1);
        yield return null;
    }
}
