using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blocking : MonoBehaviour
{
    public int numpan = 12;
    public GameObject[] pan = new GameObject[12];

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < numpan; i++)
        {
            if(pan[i] != null)
            {
                pan[i].SetActive(true);
            }
        }
        StartCoroutine(LoadSceneAfterTransition());
    }

    // Update is called once per frame
    private IEnumerator LoadSceneAfterTransition()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < numpan; i++)
        {
            if (pan[i] != null)
            {
                pan[i].SetActive(false);
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}
