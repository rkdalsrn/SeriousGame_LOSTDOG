using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Car : MonoBehaviour
{
    public GameObject dog;
    public AudioSource caraudio;
    public AudioClip jumpSound;
    RayScript rayScript;
    Vector3[] hexDirection = { new Vector3(0.5f, 0.75f, 0), new Vector3(1f, 0, 0), new Vector3(0.5f, -0.75f, 0),
                                    new Vector3(-0.5f, -0.75f, 0), new Vector3(-1f, 0, 0), new Vector3(-0.5f, 0.75f, 0) };
    public Vector3[] comeToCar = new Vector3[6];

    RaycastHit2D hitForNewPos;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog");
        rayScript = dog.GetComponent<RayScript>();
        Init_ComeToCar();
        this.caraudio = this.gameObject.AddComponent<AudioSource>();
        this.caraudio.clip = this.jumpSound;
        this.caraudio.loop = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarCheck();
    }

    void Init_ComeToCar()
    {
        for(int n = 0; n < hexDirection.Length; n++)
        {
            comeToCar[n] = transform.position + hexDirection[n];
        }
    }

    void CarCheck()
    {
       for(int n = 0; n < hexDirection.Length; n++)
        {
            if ((comeToCar[n] - dog.transform.position).magnitude < 0.03)
            {
                anim.SetFloat("isActive", 1);
                
                rayScript.isMoving = 1;
                if (n < 3)
                    rayScript.isFlip = 1;
                else rayScript.isFlip = 0;

                int layerMask = 1 << LayerMask.NameToLayer("Wall");
                hitForNewPos = Physics2D.Raycast(transform.position, hexDirection[n], 10f, layerMask);
                if (hitForNewPos.collider != null)
                {
                    rayScript.firstPos = comeToCar[n];
                    rayScript.pos = hitForNewPos.transform.position - hexDirection[n];
                    print("new position is" + rayScript.pos);
                    this.caraudio.Play();
                }
                StartCoroutine("AnimActive");
            }
        }
    }

    IEnumerator AnimActive()
    {
        yield return new WaitForSeconds(2f);
        anim.SetFloat("isActive", 0);
        
    }

}
