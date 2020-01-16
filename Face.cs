using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    //controls face behaviour
    private Animator anim;
    public IntValue difficulty;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFace();
    }

    private void ChangeFace()
    {
        if(difficulty.RunTimeValue < 1)
        {
            anim.SetInteger("FaceState", 0);
        }
        else if (difficulty.RunTimeValue == 1)
        {
            anim.SetInteger("FaceState", 1);
        }
        else if (difficulty.RunTimeValue == 2)
        {
            anim.SetInteger("FaceState", 2);
        }
        else if (difficulty.RunTimeValue == 3)
        {
            anim.SetInteger("FaceState", 3);
        }
        else if (difficulty.RunTimeValue >= 4)
        {
            anim.SetInteger("FaceState", 4);
        }
    }
}
