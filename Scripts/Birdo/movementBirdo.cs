using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBirdo : MonoBehaviour
{
    public float velocity = 1;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            jump();
        }
    }

    public void jump()
    {
        rb.velocity = Vector2.up * velocity;
    }
}
