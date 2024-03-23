using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using System.Diagnostics.Contracts;
using Unity.Mathematics;

namespace Lio
{
    public class Blower : MonoBehaviour
    {
        public bool begin;
        public float force;

        private bool runing;
        private Vector3 direction;

        // Start is called before the first frame update
        void Start()
        {
            runing = begin;
            direction = new Vector3(0,0,0);
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
                    if (hit.collider.gameObject == transform.GetChild(0).gameObject)
                    {
                        runing = !runing;
                    }
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!runing) return;
            GameObject go = collision.gameObject;
            if (go.GetComponent<Smog>() == null) return;
            Rigidbody2D rd = go.GetComponent<Rigidbody2D>();
            direction = Quaternion.Euler(transform.eulerAngles) * Vector3.right;
            rd.AddForce(force * direction, ForceMode2D.Impulse);
        }
    }
}
