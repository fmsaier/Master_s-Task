using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAttacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FPlayer")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
