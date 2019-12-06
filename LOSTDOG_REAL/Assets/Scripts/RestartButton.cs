using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart_Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
