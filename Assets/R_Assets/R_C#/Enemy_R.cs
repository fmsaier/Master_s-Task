using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R : MonoBehaviour
{
    public float health;
    public float damage;
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashTime;
    public GameObject bloodEffect;
    public GameObject floatPoint;
    public R_PlayerHealth playerhealh;
    public void Start()
    {
        playerhealh = GameObject.FindGameObjectWithTag("Player").GetComponent<R_PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void TakeDamage(float damage)
    {
        {
            GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
            gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
            health -= damage;
            //FlashColor(flashTime);
            //Instantiate(bloodEffect, transform.position, Quaternion.identity);
            //SoundsManager_R.Instance.SfxPlay("GetHit");
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void FlashColor(float time)
    {
        sr.color = Color.white;
        Invoke(nameof(ResetColor), time);
    }
    public void ResetColor()
    {
        sr.color = originalColor;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerhealh != null)
            {

                playerhealh.DamagePlayer(damage);
            }

        }
    }
}
