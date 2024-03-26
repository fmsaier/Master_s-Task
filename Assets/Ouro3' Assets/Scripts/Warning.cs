using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ouro3
{
    public enum Checkers
    {
        Cancer,Prevent
    }
    public class Warning : MonoBehaviour
    {
        public int Num = 2;
        private int Count;
        public Checkers Checker;
        public GameObject bulletC;
        public GameObject bulletP;
        public GameObject player;
        public Controller controller;
        public float shootSpeed;
        public bool Restart;
        [SerializeField]private bool change;
        private bool Shoot;
        public bool trigger;
        public Sprite[] Sprites;
        private SpriteRenderer Myrenderer;
        public float coverTime = 1;
        public float waitTime = 3;
        void Start()
        {
            Myrenderer = GetComponent<SpriteRenderer>();
            player = GameObject.FindWithTag("Player");
            controller = player.GetComponent<Controller>();
            change = true;
        }

        // Update is called once per frame
        void Update()
        {
            Restart = AllControl.instance.restart;           
            Myrenderer.sprite = Sprites[Count];

            if (Restart)
            {
                change = true;
            }
            if (change)
            {
                RandomDicider();
                change = false;
            }

            if(!controller.canMove && !trigger)
            {
                Shoot = true;
                trigger = true;
            }
            if(controller.canMove)
            {
                trigger = false;
            }

            if(Shoot)
            {
                if(Checker == Checkers.Cancer)
                {
                    ShootC();
                    Shoot = false;
                }
                if(Checker == Checkers.Prevent)
                {
                    ShootP();
                    Shoot = false;
                }
            }
        }

        private void ShootC()
        {
            GameObject b;
            b = Instantiate(bulletC, transform.position,transform.rotation);
            Rigidbody2D rb;
            rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = transform.rotation * Quaternion.Euler(0, 0, 90) * new Vector3(shootSpeed, 0, 0);
        }

        private void ShootP()
        {
            GameObject b;
            b = Instantiate(bulletP, transform.position,transform.rotation);
            Rigidbody2D rb;
            rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = transform.rotation * Quaternion.Euler(0,0,90) * new Vector3(shootSpeed, 0, 0) ;
        }

        private void RandomDicider()
        {
            Count = Random.Range(0, Num);
            if (Count == 0)
            {
                Checker = Checkers.Cancer;
            }

            if (Count == 1)
            {
                Checker = Checkers.Prevent;
            }

        }
    }

}
