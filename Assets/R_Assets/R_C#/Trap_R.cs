using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_R : MonoBehaviour
{
    public float damage;
    public R_PlayerHealth playerhealh;
    private void Start()
    {
        playerhealh = GameObject.FindGameObjectWithTag("Player").GetComponent<R_PlayerHealth>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//&& collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerhealh != null)
            {
                playerhealh.DamagePlayer(damage);
            }
        }
    }
}
