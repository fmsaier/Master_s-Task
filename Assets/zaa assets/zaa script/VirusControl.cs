using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace zaaPro
{
    public class VirusControl : MonoBehaviour
    {
        public GameObject virus1, virus2, virus3;
        float timer, timer1, timer2, timer3;
        public static VirusControl instance;
        public bool isTime;
        public bool isDestroy;
        // Start is called before the first frame update

        private void Awake()
        {
            if(instance==null)
            {
                instance = this;
            }
        }
        void Start()
        {
            timer = 0;
            timer1 = 0;
            timer2 = 0;
            timer3 = 0;
            isTime = false;
            isDestroy = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (CWall.instance.health > 0&&!isTime)
            {
                timer += Time.deltaTime;
                timer1 += Time.deltaTime;
                if (timer1 >= 3)
                {
                    Vector3 produce = new Vector3(Random.Range(-8.8f, 8.8f), 7, 0);
                    GameObject virus11 = Instantiate(virus1, produce, Quaternion.identity);
                    Rigidbody2D rb = virus11.GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector3(0, -3, 0);
                    timer1 = 0;
                }
                if (timer >= 10)
                {
                    timer2 += Time.deltaTime;
                    if (timer2 >= 4)
                    {
                        Vector3 produce = new Vector3(Random.Range(-8.8f, 8.8f), 7, 0);
                        GameObject virus22 = Instantiate(virus2, produce, Quaternion.identity);
                        Rigidbody2D rb = virus22.GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector3(0, -3, 0);
                        timer2 = 0;
                    }
                }
                if (timer >= 20)
                {
                    timer3 += Time.deltaTime;
                    if (timer3 >= 4)
                    {
                        Vector3 produce = new Vector3(Random.Range(-8.8f, 8.8f), 7, 0);
                        GameObject virus33 = Instantiate(virus3, produce, Quaternion.identity);
                        Rigidbody2D rb = virus33.GetComponent<Rigidbody2D>();
                        rb.velocity = new Vector3(0, -5, 0);
                        timer3 = 0;
                    }
                }
                if(timer>=60)
                {
             
                    timer = 0;
                    timer1 = 0;
                    timer2 = 0;
                    timer3 = 0;
                    isTime = true;
                    isDestroy = true;

                }
            }
        }
    }



}

