using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cancelbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cancelmessage;

    public void OnButtonClick()
    {
        cancelmessage.SetActive(false);
    }
}
