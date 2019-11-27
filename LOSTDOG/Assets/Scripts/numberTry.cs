using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class numberTry : MonoBehaviour
{
	public Text mytext;
    public GameObject dog;
    public GameObject cat;
    public GameObject winObject;
    int current;
    bool isfail;
    float isWin;
    int max;
    //RayScript raySc = dd.GetComponent<RayScript>();
    // Start is called before the first frame update
    void Start()
	{
        
    }
    void Update()
    {
        isfail = cat.GetComponent<Obs_Cat>().isfailed;
        isWin = winObject.GetComponent<WinObject>().isWin;
        if(isWin == 1)
        {
            mytext.text = "";
        }
        else
        {
            if (isfail == false)
            {
                current = dog.GetComponent<RayScript>().currentTry;
                max = dog.GetComponent<RayScript>().maxTry;
                mytext.text = max + " / " + current;
            }
            else
            {
                mytext.text = "";
            }
        }
    }
}
