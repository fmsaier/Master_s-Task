using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ouro3
{
    public class AllControl : MonoBehaviour
    {
        public static AllControl instance;
        public float gapTime;
        public float duringTime;
        public float timeCounter1;
        public float timeCounter2;
        public bool restart;
        public Controller controller;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
        }
        void Start()
        {
            
            controller = GameObject.FindWithTag("Player").GetComponent<Controller>();
        }

        // Update is called once per frame
        void Update()
        {
            if (restart)
            {
                timeCounter1 = gapTime; 
                restart = false;
            }
            if(timeCounter1 > 0)
            {
                timeCounter1 -= Time.deltaTime;
               
                controller.canMove = true;
            }

            if(timeCounter1 < 0)
            {
                timeCounter2 = duringTime;
                timeCounter1 = 0;
                controller.canMove = false;
            }

            if(timeCounter2 > 0)
            {
                timeCounter2 -= Time.deltaTime;
            }

            if(timeCounter2 < 0)
            {
                restart = true;
                timeCounter2 = 0;
            }
        }
    }
}

