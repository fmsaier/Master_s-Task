using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMedicine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FPlayer")
        {
            collision.gameObject.GetComponent<FPlayerController>().AddPill(6);
            Destroy(gameObject);
        }
    }
}
