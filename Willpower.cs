using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Willpower : MonoBehaviour
{
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Transform>();
    }

    public void SetSize(float sizeNormalised)
    {
        bar.localScale = new Vector3(sizeNormalised * 16.7352f, 0.5f);
    }
}
