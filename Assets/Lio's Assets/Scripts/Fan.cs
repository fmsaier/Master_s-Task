using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class Fan : MonoBehaviour
    {
        public float speed;
        public bool begin;

        private bool rotation;
        // Start is called before the first frame update
        void Start()
        {
            rotation = begin;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject ||
                        hit.collider.gameObject == transform.GetChild(0).gameObject)
                    {
                        rotation = !rotation;
                    }
                }
            }

            if(rotation)
            {
                transform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
    }
}
