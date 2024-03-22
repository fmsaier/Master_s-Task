using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDeadLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FPlayer")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(2);
            collision.gameObject.transform.position = new Vector3(-6, 0, 0);
        }
    }
}
