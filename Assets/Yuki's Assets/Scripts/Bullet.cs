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
            yield return new WaitForSeconds(5);

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            animator.SetTrigger("hit");

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.hp--;
            if (enemy.hp <= 0)
            {
                Destroy(collision.gameObject);
                PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
                if (player.score % 20 + enemy.score >= 20)
                    player.specialShotTimes++;
                player.score += enemy.score;
            }
        }

        public void DestroySelf() => Destroy(gameObject);
    }
}

