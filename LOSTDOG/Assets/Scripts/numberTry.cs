using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class numberTry : MonoBehaviour
{
	public Text mytext = null;
    public GameObject dd;
    public GameObject cc;
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
        isfail = cc.GetComponent<Obs_Cat>().isfailed;
        isWin = winObject.GetComponent<WinObject>().isWin;
        if(isWin == 1)
        {
            mytext.text = "";
        }
        else
        {
            if (isfail == false)
            {
                current = dd.GetComponent<RayScript>().currentTry;
                max = dd.GetComponent<RayScript>().maxTry;
                mytext.text = max + " / " + current;
            }
            else
            {
                mytext.text = "";
            }
        }
    }
}
