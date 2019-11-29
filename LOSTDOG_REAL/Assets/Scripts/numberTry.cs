using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class numberTry : MonoBehaviour
{
	public Text mytext = null;
    public GameObject dog;
    public GameObject cat;
    public GameObject winObject;
    int current;
    bool isfail;
    float isWin;
    int max;

    void Start()
	{
        dog = GameObject.Find("Dog");
        cat = GameObject.Find("Cat");
        winObject = GameObject.Find("WinObject");
        mytext = transform.GetChild(0).GetComponent<Text>();
    }
    void Update()
    {
        isfail = cat.GetComponent<Obs_Cat>().isfailed;
        isWin = winObject.GetComponent<WinObject>().isWin;
        if(isWin == 1)
        {
            mytext.text = "SUCCESS";
        }
        else
        {
            if (isfail == false)
            {
                current = dog.GetComponent<RayScript>().currentTry;
                max = dog.GetComponent<RayScript>().maxTry;
                if (current > max-2)
                    mytext.text= "<color=red>" + current + "</color>" + " / " + max;
                else
                    mytext.text = current + " / " + max;
                
            }
            else
            {
                mytext.text = "FAILED";
            }
        }
    }
}
