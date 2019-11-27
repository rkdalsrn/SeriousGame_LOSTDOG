using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* ClickedButton은 Canvas/Button에 할당되어야 한다.
 * 퍼즐에서 어떤 버튼이 눌렸는지 알려준다.
 */

public class ClickedButton : MonoBehaviour
{
    public RayScript target;

    public void OnButtonClick(GameObject button)
    {
        int activatedButton = int.Parse(button.name.Substring(0, 1));
        print(activatedButton);

        for (int n = 0; n < 6; n++)
        {
            target.buttonNum[n] = 0;
        }
        target.buttonNum[activatedButton - 1] = 1;
        print("target is" + activatedButton + "and it is" + target.buttonNum[activatedButton - 1]);    //Log
    }
}

