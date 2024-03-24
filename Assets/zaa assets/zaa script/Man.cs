using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zaaPro
{

    public class Man : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject arrow;
        private float speed = 5f;
        private Animator animator;
        private  Rigidbody2D rb;
        public Transform target;
        public static Man instance;
        public bool isDie;
        public bool isMove;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        void Start()
        {

            animator = GetComponent<Animator>();
            isDie = false;
            isMove = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                animator.SetBool("isLeft", true);


            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                animator.SetBool("isRight", true);

            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);

            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);

            }
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && !VirusControl.instance.isTime&&!isMove)
            {
                
                    GameObject arrow1 = Instantiate(arrow, target.position, Quaternion.identity);
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 thisPos = new Vector2(target.position.x, target.position.y);
                    float angle = angleChange(mousePos, thisPos);
                    arrow1.transform.rotation = Quaternion.Euler(0, 0, angle);
                    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - target.position;
                    arrow1.GetComponent<Rigidbody2D>().velocity = direction / direction.magnitude * 10f;
                
            }
           

        }
        
    
        private float angleChange(Vector2 a, Vector2 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("deadline"))
            {
                isDie = true;
                VirusControl.instance.isDestroy = true;
                Destroy(gameObject);
            }
        }

        public void Move()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                animator.SetBool("isLeft", true);


            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                animator.SetBool("isRight", true);

            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);

            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);

            }
        }

        public void Walk()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1);
                if (hit.collider.tag=="LeftControl")
                {
                    transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                    animator.SetBool("isLeft", true);
                }
                if(hit.collider.tag=="RightControl")
                {

                    transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                    animator.SetBool("isRight", true);
                }
                if (hit.collider.tag == "LeftControl" && hit.collider.tag == "RightControl")
                {
                    animator.SetBool("isLeft", false);
                    animator.SetBool("isRight", false);

                }
            }
        }
    }


}


