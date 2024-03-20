using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R : MonoBehaviour
{
    public float health;
    public float damage;
    private SpriteRenderer sr;
    public GameObject floatPoint;
    public R_PlayerHealth playerhealh;
    public void Start()
    {
        playerhealh = GameObject.FindGameObjectWithTag("Player").GetComponent<R_PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        {
            //GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
            //gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
            health -= damage;
            //Instantiate(bloodEffect, transform.position, Quaternion.identity);
            //SoundsManager_R.Instance.SfxPlay("GetHit");
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
