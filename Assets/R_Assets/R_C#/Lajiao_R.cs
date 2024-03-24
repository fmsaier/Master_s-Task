using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lajiao_R : MonoBehaviour
{
    private GameObject p;
    public float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p = collision.gameObject;
            R_PlayerHealth p1;
            p1 = collision.gameObject.GetComponent<R_PlayerHealth>();
            p1.DamagePlayer(damage);
            R_HealthBar.healthPresent = p1.health;
            SoundsManager_R.Instance_RS.SfxPlay("Eat");
            Destroy(gameObject);
        }
    }
}
