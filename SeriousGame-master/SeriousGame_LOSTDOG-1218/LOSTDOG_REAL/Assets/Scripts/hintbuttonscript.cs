﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hintbuttonscript : MonoBehaviour
{
    /*
    public GameObject hintPosition;
    int isHintActive = 0;

    void Start()
    {
        hintPosition = GameObject.Find("Button_Hint").transform.GetChild(0).gameObject;
    }
    public void Hint_Click()
    {
        if(isHintActive == 0)
        {
            hintPosition.SetActive(true);
            isHintActive++;
            StartCoroutine("HintOff");
        }
        else
        {
            hintPosition.SetActive(false);
            isHintActive--;
        }
    }

    IEnumerator HintOff()
    {
        yield return new WaitForSeconds(1.5f);
        hintPosition.SetActive(false);
    }*/

    public GameObject hintmessage;
    public Vector3[] posDog = { new Vector3(-1f, 1.25f, 0f), new Vector3(0.5f, -1f, 0f), new Vector3(2f, 1.25f, 0f) };
    public Vector3 firstPos = new Vector3(-2.5f, -1, 0f);
    Vector3 dogScale;

    public int isFlip = 0;
    public int numOfPos = 3;
    public int currentNumOfPos = 0;
    public int isMoving = 1;
    public int valid = 0;

    public bool mingu;

    private void Start()
    {
        hintmessage.SetActive(false);
        mingu = false;
    }

    //public void onPointerDownRaceButton()
    //{
    //    hintmessage.SetActive(true);
    //}
    //public void onPointerUpRaceButton()
    //{
    //    hintmessage.SetActive(false);
    //}
    /*
    void InitDog()
    {
        anim = GetComponent<Animator>();
        hintmessage.transform.position = firstPos;
        dogScale = transform.localScale;
    }

    //GameObject Dog = Instantiate(Resources.Load("hintDog")) as GameObject;

    private void FixedUpdate()
    {
        if (valid == 1)
        {
            hintmessage.SetActive(true);
            if (isMoving == 0)
            {
                if (currentNumOfPos < numOfPos)
                    currentNumOfPos++;
                else
                {
                    hintmessage.SetActive(false);
                    valid = 0;
                }
            }
            //SetAnimation();
            MakeDogMove(currentNumOfPos);
        }
        else
        {
            ExitAnimation();
            hintmessage.transform.position = firstPos;
            //hintmessage.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.6f);
            currentNumOfPos = 0;
            isMoving = 1;
        }
    }*/

    public void onClicked()
    {
        StartCoroutine("hintStart");
    }

    IEnumerator hintStart()
    {
        hintmessage.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hintmessage.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        hintmessage.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hintmessage.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        hintmessage.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hintmessage.SetActive(false);
    }
    /*
    void MakeDogMove(int i)
    {
        isMoving = 1;
        FlipDog(isFlip);
        float moveSpeed = Time.deltaTime * 2.0f;
        if (i > numOfPos - 1) i = numOfPos - 1;
        float distance = Mathf.Sqrt((hintmessage.transform.position.x - posDog[i].x) * (hintmessage.transform.position.x - posDog[i].x)
                            + (hintmessage.transform.position.y - posDog[i].y) * (hintmessage.transform.position.y - posDog[i].y));
        if (hintmessage.transform.position.x < posDog[i].x)
            isFlip = 1;
        else
        {
            isFlip = 0;
        }
        if (distance > 0.05f)
        {
            hintmessage.transform.position = Vector3.MoveTowards(hintmessage.transform.position, posDog[i], moveSpeed);
        }
        else isMoving = 0;
    }

    void FlipDog(int isFlip)
    {
        if (isFlip == 0)
        {
            dogScale.x = 0.9389671f;
            dogScale.y = 0.9389671f;
        }
        else
        {
            dogScale.x = -0.9389671f;
            dogScale.y = 0.9389671f;
        }
        hintmessage.transform.localScale = dogScale;
    }

    void SetAnimation()
    {
        anim.SetFloat("speed", 1);
    }

    void ExitAnimation()
    {
        //anim.SetFloat("isWin", 1);
    }*/


    /*
    //// Start is called before the first frame update
    //public GameObject hintmessage;
    //public Vector3[] posDog = { new Vector3(-0.75f, 1.25f, 0f), new Vector3(0.75f, -1f, 0f) };
    //public Vector3 firstPos = new Vector3(-2.25f, -1f, 0f);
    //Vector3 dogScale;

    //public int isFlip = 0;
    //public int numOfPos = 2;
    //public int currentNumOfPos = 0;
    //public int isMoving = 1;
    //public int valid = 0;
    //Animator anim;

    //private void Start()
    //{
    //    hintmessage.SetActive(false);
    //    InitDog();
    //}

    ////public void onPointerDownRaceButton()
    ////{
    ////    hintmessage.SetActive(true);
    ////}
    ////public void onPointerUpRaceButton()
    ////{
    ////    hintmessage.SetActive(false);
    ////}

    //void InitDog()
    //{
    //    anim = GetComponent<Animator>();
    //    hintmessage.transform.position = firstPos;
    //    dogScale = transform.localScale;
    //}

    //GameObject Dog = Instantiate(Resources.Load("hintDog"))as GameObject;

    //private void FixedUpdate()
    //{
    //    if(valid == 1)
    //    {
    //        hintmessage.SetActive(true);
    //        if (isMoving == 0)
    //        {
    //            if (currentNumOfPos < numOfPos)
    //                currentNumOfPos++;
    //            else
    //            {
    //                hintmessage.SetActive(false);
    //                valid = 0;
    //            }
    //        }
    //        //SetAnimation();
    //        MakeDogMove(currentNumOfPos);
    //    }
    //    else
    //    {
    //        ExitAnimation();
    //        hintmessage.transform.position = firstPos;
    //        hintmessage.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.6f);
    //        currentNumOfPos = 0;
    //        isMoving = 1;
    //    }
    //}

    //public void onClicked()
    //{
    //    valid = 1;
    //}

    //void MakeDogMove(int i)
    //{
    //    isMoving = 1;
    //    float moveSpeed = Time.deltaTime * 2.0f;
    //    if (i > numOfPos - 1) i = numOfPos - 1;
    //    float distance = Mathf.Sqrt((hintmessage.transform.position.x - posDog[i].x) * (hintmessage.transform.position.x - posDog[i].x)
    //                        + (hintmessage.transform.position.y - posDog[i].y) * (hintmessage.transform.position.y - posDog[i].y));
    //    if (distance > 0.05f)
    //    {
    //        hintmessage.transform.position = Vector3.MoveTowards(hintmessage.transform.position, posDog[i], moveSpeed);
    //    }
    //    else isMoving = 0;
    //}

    //void FlipDog(int isFlip)
    //{
    //    if (isFlip == 0)
    //        dogScale.x = 1;
    //    else dogScale.x = -1;
    //    transform.localScale = dogScale;
    //}

    //void SetAnimation()
    //{
    //    anim.SetFloat("speed", 1);
    //}

    //void ExitAnimation()
    //{
    //    //anim.SetFloat("isWin", 1);
    //}

    public int valid = 0;
    GameObject Dog;
    public Vector3[] posDog = { new Vector3(-0.75f, 1.25f, 0f), new Vector3(0.75f, -1f, 0f) };
    public Vector3 firstPos = new Vector3(-2.25f, -1f, 0f);
    Vector3 dogScale;
    public int isFlip = 0;
    public int numOfPos = 2;
    public int currentNumOfPos = 0;
    public int isMoving = 1;

    public void onClicked()
    {
        if(GameObject.Find("hintDog") == null)
        {
            Dog = Instantiate(Resources.Load("hintDog")) as GameObject;
        }
        valid = 1;
    }

    private void FixedUpdate()
    {
        if (valid == 1)
        {
            if (isMoving == 0)
            {
                if (currentNumOfPos < numOfPos)
                    currentNumOfPos++;
                else
                {
                    valid = 0;
                }
            }
            MakeDogMove(currentNumOfPos);
        }
        else
        {
            Destroy(Dog);
        }
    }

    void MakeDogMove(int i)
    {
        isMoving = 1;
        float moveSpeed = Time.deltaTime * 2.0f;
        if (i > numOfPos - 1) i = numOfPos - 1;
        float distance = Mathf.Sqrt((Dog.transform.position.x - posDog[i].x) * (Dog.transform.position.x - posDog[i].x)
                            + (Dog.transform.position.y - posDog[i].y) * (Dog.transform.position.y - posDog[i].y));
        if (distance > 0.05f)
        {
            Dog.transform.position = Vector3.MoveTowards(Dog.transform.position, posDog[i], moveSpeed);
        }
        else isMoving = 0;
    }
     */
}
