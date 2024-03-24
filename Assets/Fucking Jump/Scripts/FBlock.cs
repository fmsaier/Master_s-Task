using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBlock : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(-4 * Time.deltaTime, 0, 0));
        if (transform.position.x < -9.5)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FPlayer")
        {
            other.GetComponent<PlayerStats>().TakeDamage(1.5f);
            Destroy(gameObject);
        }
    }
}
