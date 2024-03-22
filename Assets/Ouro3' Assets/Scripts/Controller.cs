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
    // Start is called before the first frame update
       void Start()
       {
            size = transform.localScale.x;
            step = size * r;
       }

    // Update is called once per frame
       void Update()
       {  
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + step,transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
            }
        }
    }

}
