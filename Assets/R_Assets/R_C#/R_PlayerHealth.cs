using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_PlayerHealth : MonoBehaviour
{
    public float health;
    public Animator playerAim;
    private float hitCD = 1f;
    private Rigidbody2D rb;

    bool isStruggle = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAim = GetComponent<Animator>();
        R_HealthBar.healthMax = health;
        R_HealthBar.healthPresent = health;
    }
    private void Update()
    {
        hitCD -= Time.deltaTime;
        if (hitCD <= 0)
        {
            hitCD = 0;
        }
        if (health <= 0)
        {
            health = 0;
            rb.velocity = new Vector2(0, 0);
            R_Player P1;
            P1 = GetComponent<R_Player>();
            P1.isDeath = true;
        }
        if (health > R_HealthBar.healthMax)
        {
            health = R_HealthBar.healthMax;
            R_HealthBar.healthPresent = health;

        }
        if (health < R_HealthBar.healthMax * 0.3f && !isStruggle)
        {
            //soundsManager.Instance.PlayMusic("Struggle");
            isStruggle = true;
        }
    }

    public void DamagePlayer(float damage)
    {
        R_Player P1;
        P1 = GetComponent<R_Player>();
        if (hitCD == 0)
        {
            hitCD = 1f;
            health -= damage;
            R_HealthBar.healthPresent = health;
            if (health <= 0)
            {
                playerAim.SetTrigger("Death");
                Invoke(nameof(Death), 2f);
            }
            else if (health > 0)
            {
                playerAim.SetTrigger("isHit");
            }

        }

    }
    void Death()
    {
        Destroy(gameObject);
    }

}
