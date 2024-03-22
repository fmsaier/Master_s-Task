using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FVegetable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FPlayer")
        {
            collision.gameObject.GetComponent<PlayerStats>().AddHealth();
            Destroy(gameObject);
        }
    }
}
