using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/* ButtonOnScreen은 Main Camera에 할당되어야 한다.
 * 이 Script는 화면에 뜨는 버튼의 위치를 정해준다.
 */

public class ButtonOnScreen : MonoBehaviour
{
    public Transform Dog;
    public Transform[] buttonPos = new Transform[6];
    Camera camera;
    Vector3[] screenPos = new Vector3[6];

    Vector3[] direction = { new Vector3(0.5f, 0.75f, 0), new Vector3(1f, 0, 0), new Vector3(0.5f, -0.75f, 0),
                            new Vector3(-0.5f, -0.75f, 0), new Vector3(-1f, 0, 0), new Vector3(-0.5f, 0.75f, 0) };

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        for(int n =0 ; n < screenPos.Length ; n++)
        {
            screenPos[n] = camera.WorldToScreenPoint(Dog.position + direction[n]);
            buttonPos[n].position = new Vector3(screenPos[n].x, screenPos[n].y, 0);
        }
    }
}