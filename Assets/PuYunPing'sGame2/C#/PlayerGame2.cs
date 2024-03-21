using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame2PYP : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public HuanPYP Huan;
    public int health = 3;
    public HealthPYP Health;
    private Animator myAnim;
    public float WudiTime=0f;

    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, rb.velocity.y);
        Huan = FindObjectOfType<HuanPYP>();

        Health= FindObjectOfType<HealthPYP>();

        myAnim = GetComponent<Animator>();

        audioSource = transform.GetChild(2).GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
        if(WudiTime>=0f)
        {
            WudiTime-=Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            speed = -speed;
            rb.velocity = new Vector2(speed, 3.05f);
            Huan.PanDing();
            WudiTime = 0.3f;
        }
        if (WudiTime<=0f)
        {
            if (collision.CompareTag("Upwall"))
            {
                if (audioSource != null)
                {
                    audioSource.Play();
                }
                Health.HealthJiLu();
                myAnim.SetTrigger("Hurt");
                health -= 1;
                WudiTime = 0.3f;
            }            
        }
    }
}
