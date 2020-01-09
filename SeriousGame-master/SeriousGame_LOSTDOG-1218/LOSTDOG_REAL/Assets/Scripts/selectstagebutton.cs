using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectstagebutton : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnButtonClick(GameObject button)
    {
        int activatedButton = int.Parse(button.name.Substring(0, 1));
        if(activatedButton == 1)
        {
            SceneManager.LoadScene(3);
        }
        else if(activatedButton == 2)
        {
            SceneManager.LoadScene(4);
        }
        else if (activatedButton == 3)
        {
            SceneManager.LoadScene(5);
        }
        else if (activatedButton == 4)
        {
            SceneManager.LoadScene(6);
        }
        else if (activatedButton == 5)
        {
            SceneManager.LoadScene(7);
        }
    }
}
