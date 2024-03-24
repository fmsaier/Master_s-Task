using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_R : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float disAppearTime;

    private Rigidbody2D myRb2D;

    private void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy_R e;
            e = collision.GetComponent<Enemy_R>();
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Filp();
        disAppearTime -= Time.deltaTime;
        if(disAppearTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Filp()
    {
            if (myRb2D.velocity.x > 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRb2D.velocity.x < -0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
    }
}
