using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treats : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Collider2D coll;
    private Vector2 startingPos;
    public float XBound = 8.2f;
    public float YBound = 4.2f;
    public float startingVelocity = 1.5f;
    private Vector2 startingDirection;
    public int treatID;
    public float timeBeforeDestroy = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
        startingPos = new Vector2(Random.Range(-XBound, XBound), Random.Range(-YBound, YBound));
        transform.position = startingPos;
        startingDirection = new Vector2(startingVelocity, startingVelocity);
        Impulse();
        Destroy(this.gameObject, timeBeforeDestroy);
    }

    private void Impulse()
    {
        rb2d.AddForce(startingDirection, ForceMode2D.Impulse);
    }
}
