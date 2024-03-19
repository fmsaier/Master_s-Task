using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPYP : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {

    }

    public void ToStart()
    {
        rb.velocity = new Vector2(6, rb.velocity.y);
        rb.gravityScale = 0.5f;
    }
}