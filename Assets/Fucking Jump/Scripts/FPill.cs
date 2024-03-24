using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FEnemy")
        {
            collision.gameObject.GetComponent<FAi>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "FAttacker")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
