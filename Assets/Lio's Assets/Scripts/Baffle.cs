using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using UnityEngine.UIElements;

namespace Lio
{
    public class Baffle : MonoBehaviour
    {
        public float time;
        public float dgree;
        public LayerMask layerMask;

        private bool rotating;

        // Start is called before the first frame update
        void Start()
        {
            rotating = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (rotating) return;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D collider = Physics2D.OverlapPoint(mousePosition, layerMask);

                if (collider != null)
                {
                    if (collider.gameObject == gameObject||
                        collider.gameObject==transform.GetChild(0).gameObject)
                    {
                        StartCoroutine(RotateObject());
                    }
                }
            }
        }

        IEnumerator RotateObject()
        {
            rotating = true;
            //起始角度
            float begin = transform.eulerAngles.z;
            //终止角度
            float end = transform.eulerAngles.z + dgree;
            //旋转速度
            float speed = (end - begin) / time;
            //开始时间
            float bt = Time.time;

            while (Time.time - bt < time)
            {
                transform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, end);
            rotating = false;
        }
    }
}
