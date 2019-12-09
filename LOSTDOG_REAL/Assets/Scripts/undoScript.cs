using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dog;
    public int mingu = 0; //hint는 한번만 가능

    void Start()
    {
        dog = GameObject.Find("Dog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked()
    {
        if(dog.GetComponent<RayScript>().currentTry > 0)
        {
            if(mingu == 0 && dog.GetComponent<RayScript>().isMoving == 0)
            {
                mingu = 1;
                dog.GetComponent<RayScript>().currentTry = dog.GetComponent<RayScript>().currentTry - 1;
                dog.transform.position = dog.GetComponent<RayScript>().undopos;
                dog.GetComponent<RayScript>().firstPos = dog.transform.position;
                dog.GetComponent<RayScript>().pos = dog.transform.position;
            }
        }
    }
}
