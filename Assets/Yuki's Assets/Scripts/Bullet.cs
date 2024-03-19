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
        }

        public void DestroySelf() => Destroy(gameObject);
    }
}

