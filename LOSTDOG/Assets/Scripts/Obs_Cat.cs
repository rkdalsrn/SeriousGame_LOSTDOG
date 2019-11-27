using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* CatRule은 고양이 장애물의 기믹이다.
 * dog를 넣어줘야한다.
 */

public class Obs_Cat : MonoBehaviour
{
    public GameObject dog;
    int isMoving;
    public bool isfailed = false;
    public Vector3 startPoint;
    GameObject rayScript;
    
    void Update()
    {
        CatFunction();
        InitPos();
    }

    void CatFunction()
    {
        startPoint = dog.GetComponent<RayScript>().startPoint;
        isMoving = dog.GetComponent<RayScript>().isMoving;
    }

    void InitPos()
    {
        if (isMoving == 0 && dog.transform.position == transform.position)
        {
            isfailed = true;
            print("Fail!");     //debug
            Destroy(dog);
            StartCoroutine(LoadSceneAfterTransition());
        }
        else isfailed = false;
    }

    private IEnumerator LoadSceneAfterTransition()
    {
        yield return new WaitForSeconds(1f);       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
