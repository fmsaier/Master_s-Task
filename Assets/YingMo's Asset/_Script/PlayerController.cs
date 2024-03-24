using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

namespace YingMo
{
    public class PlayerController : MonoBehaviour
    {
        public Animator Myanimator;
        public Rigidbody2D Myrigidbody;
        public List<GameObject> HealthImage;
        public GameObject Bullet;
        public GameObject Handle;
        public GameObject BossFightManager;
        public BossFightManager BFM;
        public GameObject DeadUI;

        [Header ("��������")]
        public float MoveSpeed;
        public float JumpSpeed;
        public int Health;
        public int MaxHealth;
        public bool isjumping;
        public static bool BossComing;

        public event Action PlayerDead;
        public event Action BossFight;

        void Start()
        {
            BFM = BossFightManager.GetComponent<BossFightManager>();
            BossFight += BFM.BossFight;
            Myrigidbody = GetComponent<Rigidbody2D>();
            Myanimator = GetComponent<Animator>();
            Health = 3;
            Time.timeScale = 0;
        }

        void Update()
        {
            if (!BossComing) AutoMove();
            else ControledMove();
        }

        void AutoMove()
        {
            Myrigidbody.velocity = new Vector2(MoveSpeed, Myrigidbody.velocity.y);
        }

        void ControledMove()
        {
            float posX = Handle.transform.localPosition.x; //��ȡ Handle ����ı��� X ����ֵ
            float horizontal_move = posX / 128f; //ģ�� Input.GetAxis �ķ���ֵ
            float faced_direction;
            
            if (posX > 0)
            {
                faced_direction = 1; //ģ�� Input.GetAxisRaw ���� 1
            }
            else if (posX < 0)
            {
                faced_direction = -1; //ģ�� Input.GetAxisRaw ���� -1
            }
            else
            {
                faced_direction = 0; //ģ�� Input.GetAxisRaw ���� 0
            }
            /*�޶�����*/

            //��ɫ�ƶ�
            Myrigidbody.velocity = new Vector2(horizontal_move * MoveSpeed , Myrigidbody.velocity.y);
            //��ɫ����
            if (faced_direction != 0)
            {
                transform.localScale = new Vector3(faced_direction, 1, 1);
            }
        }


        public void Jump()
        {
            if (!isjumping)
            {
                isjumping = true;
                Myrigidbody.velocity = new Vector2(Myrigidbody.velocity.x, JumpSpeed);
                Myanimator.SetBool("Jump", true);
                Myanimator.SetBool("Running", false);
            }
        }

        public void Shoot()
        {
            Instantiate(Bullet,transform.position + Vector3.right,Quaternion.identity);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isjumping = false;
                Myanimator.SetBool("Jump", false);
                Myanimator.SetBool("Running", true);
            }

            if (collision.gameObject.CompareTag("EnemyAttack"))
            {
                RemoveHealth();
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sign")) BossFight?.Invoke();
            BossComing = true;

            if (collision.gameObject.CompareTag("EnemyFarAttack"))
            {

                RemoveHealth();
                Destroy(collision.gameObject);
            }
        }

        public void AddHealth()
        {
            HealthImage[Health].SetActive(true);
            Health++;
            Health = Health > 6 ?6:Health;
        }

        public void RemoveHealth() 
        {
            Health--;
            Health = Health < 0 ?0 : Health;
            HealthImage[Health].SetActive(false);
            if (Health == 0) Dead();
        }

        void Dead()
        {
            DeadUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}