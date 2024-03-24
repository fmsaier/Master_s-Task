using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class Duct : MonoBehaviour
    {
        public float force;
        public float range;
        public bool begin;
        public Vector2 velRange;
        public LayerMask layerMask;

        public GameObject smog;

        private Transform export;
        private int number;
        private bool runing;
        // Start is called before the first frame update
        void Start()
        {
            export = transform.GetChild(0);
            number = 0;
            runing = begin;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D collider = Physics2D.OverlapPoint(mousePosition, layerMask);

                if (collider != null)
                {
                    if (collider.gameObject == gameObject)
                    {
                        runing = !runing;
                    }
                }
            }

            if(number>0)
            {
                GameObject ob = Instantiate(smog, export.transform.position, Quaternion.identity);
                Rigidbody2D rd = ob.GetComponent<Rigidbody2D>();
                float dir = Random.Range(0f, 180f);
                Vector3 direction = Quaternion.Euler(new Vector3(0, 0, dir)) * Vector3.right;
                Vector3 vel = direction * Random.Range(velRange.x, velRange.y);
                rd.velocity = vel;
                number--;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!runing) return;
            GameObject go = collision.gameObject;
            if (go.GetComponent<Smog>() == null) return;
            if(Vector3.Distance(go.transform.position,transform.position)<=range)
            {
                Destroy(go);
                number++;
            }
            else
            {
                Vector3 direction = transform.position - go.transform.position;
                direction = direction.normalized;
                Rigidbody2D rd = go.GetComponent<Rigidbody2D>();
                rd.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
