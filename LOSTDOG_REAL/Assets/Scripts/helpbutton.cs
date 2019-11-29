using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject helpmessage;

    void Start()
    {
        helpmessage.SetActive(false);
    }

    public void OnButtonClick()
    {
        helpmessage.SetActive(true);
    }
}
