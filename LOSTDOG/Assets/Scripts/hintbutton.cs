using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintbutton : MonoBehaviour
{
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
}
