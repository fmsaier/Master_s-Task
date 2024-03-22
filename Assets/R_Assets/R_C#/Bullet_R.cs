using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_R : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float disAppearTime;
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
        disAppearTime -= Time.deltaTime;
        if(disAppearTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
