using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure_R : MonoBehaviour
{
    private GameObject p;
    public float cure;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p = collision.gameObject;
            R_PlayerHealth p1;
            p1 = collision.gameObject.GetComponent<R_PlayerHealth>();
            p1.health += cure;
            R_HealthBar.healthPresent = p1.health;
            Destroy(gameObject);
        }
    }
}
