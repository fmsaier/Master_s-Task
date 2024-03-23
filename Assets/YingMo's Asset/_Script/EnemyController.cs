using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YingMo
{
    public class EnemyController : MonoBehaviour
    {
        public int MaxHealth;
        public int Health;
        public int PlayerAttackValue;
        public float Last_Attack_Time;
        public GameObject Attack_Pref;
        public GameObject Player;
        public Animator Animator;
        public Coroutine IEFarAttack;
        public Coroutine IECloseAttack;
        public GameObject SuccessUI;

        public event Action Finished;

        void Start()
        {
            Animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Health <= 0) StartCoroutine(nameof(Death));
            if (Time.time - Last_Attack_Time > 5 && IECloseAttack == null && IEFarAttack == null) Attack();
        }

        void Attack()
        {
            Last_Attack_Time = Time.time;
            if (Vector3.Distance(transform.position, Player.transform.position) <= 3) { IECloseAttack = StartCoroutine(nameof(CloseAttack)); }
            else { IEFarAttack = StartCoroutine(nameof(FarAttack)); }
        }

        IEnumerator FarAttack()
        {
            Animator.SetBool("farattack",true);
            yield return new WaitForSeconds(1.4f);
            Animator.SetBool("farattack", false);
            for (int i=0; i<3;i++ )
            {
                GameObject newFarAttack = Instantiate(Attack_Pref, transform.position - 1.5f*Vector3.up - Vector3.right,Quaternion.identity);
                Rigidbody2D rigidbody = newFarAttack.GetComponent<Rigidbody2D>();
                rigidbody.velocity = -7 * Vector2.right;
                yield return new WaitForSeconds(0.3f);
            }
            IEFarAttack = null;
        }

        IEnumerator CloseAttack()
        {
            Animator.SetBool("CloseAttack",true);
            yield return new WaitForSeconds(0.67f);
            Animator.SetBool("CloseAttack",false);
            IECloseAttack = null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerAttack"))
            {
                StartCoroutine(nameof(BeAttacked));
                Destroy(collision.gameObject);
            }
        }

        IEnumerator BeAttacked()
        {
            Animator.SetBool("BeAttacked", true);
            Health -= PlayerAttackValue;
            Health = Health < 0 ? 0 : Health;
            yield return new WaitForSeconds(0.6f);
            Animator.SetBool("BeAttacked", false);
        }

        IEnumerator Death()
        {
            Animator.SetBool("Dead", true);
            yield return new WaitForSeconds(1.2f);
            SuccessUI.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
            
        }
    }
}
