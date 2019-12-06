using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    public Animator anim;
    public float isClicked;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = 0f;
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(isClicked < 0.5f)
        {
            print("Panel = On");
            isClicked = 1.0f;
            anim.SetFloat("isPanelButtonClicked", isClicked);
            return;
        }

        if(isClicked > 0.5f)
        {
            print("Panel = Off");
            isClicked = 0.0f;
            anim.SetFloat("isPanelButtonClicked", isClicked);
            return;
        }
    }
}
