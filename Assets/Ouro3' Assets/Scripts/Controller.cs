using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ouro3
{
    public class Controller : MonoBehaviour
    {

        private float size;
        private float step;
        public float r;
        public bool canMove;
        [SerializeField] Vector3 iniPosition;
        private float upRage;
        private float downRage;
        private float rightRage;
        private float leftRage;
        // Start is called before the first frame update

        private void OnEnable()
        {
            iniPosition = transform.position;
        }
        void Start()
       {
            size = transform.localScale.x;
            step = size * r;
            upRage = iniPosition.y + step;
            downRage = iniPosition.y - step;
            rightRage = iniPosition.x + step;
            leftRage = iniPosition.x - step;
       }

    // Update is called once per frame
       void Update()
       {  
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GoUp();
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    GoDown();
                }

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    GoLeft();
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    GoRight();
                }       
        }

        public void GoUp()
        {
            if (transform.position.y < upRage && canMove)
                transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
        }

        public void GoDown()
        {
            if (transform.position.y > downRage && canMove)
                transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
        }

        public void GoRight()
        {
            if (transform.position.x < rightRage && canMove)
                transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
        }

        public void GoLeft()
        {
            if (transform.position.x > leftRage && canMove)
                transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
        }
    }

}
