using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScope : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private Vector3 change;
    public float move_speed;
    public float maxXPosition;
    public float maxYPosition;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        Follow();
    }

    private void Follow()
    {
        change.Normalize();
        rb2d.MovePosition(transform.position + change * Time.deltaTime * move_speed);
    }
}
