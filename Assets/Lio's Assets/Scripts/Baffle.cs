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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject||
                        hit.collider.gameObject==transform.GetChild(0).gameObject)
                    {
                        StartCoroutine(RotateObject());
                    }
                }
            }
        }

        IEnumerator RotateObject()
        {
            rotating = true;
            //��ʼ�Ƕ�
            float begin = transform.eulerAngles.z;
            //��ֹ�Ƕ�
            float end = transform.eulerAngles.z + dgree;
            //��ת�ٶ�
            float speed = (end - begin) / time;
            //��ʼʱ��
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
