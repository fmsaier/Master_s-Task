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
        //HealthBar.healthMax = health;
        //HealthBar.healthPresent = health;
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
        //if (health > HealthBar.healthMax)
        {
           // health = HealthBar.healthMax;
           // HealthBar.healthPresent = health;

        }
        //if (health < HealthBar.healthMax * 0.3f && !isStruggle)
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
            if (!P1.isDash)
            {
                hitCD = 1f;
                health -= damage;
               // HealthBar.healthPresent = health;
                if (health <= 0)
                {
                    playerAim.SetBool("Death", true);
                    Invoke(nameof(Death), 2f);
                }
                else if (health > 0)
                {
                    playerAim.SetTrigger("isHit");
                }
            }

        }

    }
    void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(7);

    }

}
