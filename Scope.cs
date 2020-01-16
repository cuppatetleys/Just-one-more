using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public TreatSpawner treatSpawner;
    public Animator faceAnim;

    /*private void Update()
    {
        if (!treatSpawner)
            treatSpawner = FindObjectOfType<TreatSpawner>();
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Treat"))
        {
            int id = collision.GetComponent<Treats>().treatID;
            //Debug.Log("Hovering on Treat");
            treatSpawner.DecreaseWillPower(id);
        }
        else if(collision.CompareTag("Non-Treat"))
        {
            int id = collision.GetComponent<Treats>().treatID;
            //Debug.Log("Hovering on Non-Treat");
            treatSpawner.IncreaseWillPower(id);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        faceAnim.enabled = true;
    }
}
