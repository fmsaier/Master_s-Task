using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Animator animator;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            StartCoroutine(RegularDestruction());
        }

        private IEnumerator RegularDestruction()
        {
            yield return new WaitForSeconds(10);

            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("hit");

            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.hp--;
            if (enemy.hp <= 0)
            {
                Destroy(collision.gameObject);
                GameObject.Find("Player").GetComponent<PlayerController>().score += enemy.score;
            }
        }

        public void DestroySelf() => Destroy(gameObject);
    }
}

