using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace zaaPro
{
    public class ControlButtton : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject man;
        private Animator ani;
        float timer;
        private bool isLeft, isRight;
        private void Start()
        {
            if (man != null)
            {
                ani = man.GetComponent<Animator>();
            
            }

        }
        // Update is called once per frame

        private void OnMouseDown()
        {
            if (man != null)
            {
                if (gameObject.tag == "LeftControl")
                {
               
                    ani.SetBool("isLeft", true);
                    isLeft = true;
                    Man.instance.isMove = true;
                    timer = 0;
                }
                if (gameObject.tag == "RightControl")
                {
                   
                    ani.SetBool("isRight", true);
                    isRight = true;
                    Man.instance.isMove = true;
                    timer = 0;
                }
                if (gameObject.tag == "LeftControl" && gameObject.tag == "RightControl")
                {
                    ani.SetBool("isLeft", false);
                    ani.SetBool("isRight", false);
                    isLeft = false;
                    isRight = false;
                }
            }
        }



        private void OnMouseUp()
        {
            if (man != null)
            {
                ani.SetBool("isLeft", false);
                ani.SetBool("isRight", false);
                isLeft = false;
                isRight = false;
            }
        }

        private void Update()
        {
            if(isLeft)
            {
                Man.instance.transform.Translate(new Vector3(-1, 0, 0) * 5f * Time.deltaTime);
            }
            if(isRight)
            {
                Man.instance.transform.Translate(new Vector3(1, 0, 0) * 5f * Time.deltaTime);
            }
            if(Man.instance.isMove)
            {
                timer += Time.deltaTime;
                if(timer>=0.1f)
                {
                    Man.instance.isMove = false;
                    timer = 0;
                }
            }
        }
    }
}

