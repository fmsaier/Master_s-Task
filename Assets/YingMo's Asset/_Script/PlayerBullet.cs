using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float MoveSpeed;
    public float LifeTime;
    public float MaxLifeTime;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody.velocity = MoveSpeed * Vector2.right;
        LifeTime += Time.deltaTime;
        if (LifeTime >= MaxLifeTime) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAttack")||collision.gameObject.CompareTag("Ground")) Destroy(gameObject);
    }

}
