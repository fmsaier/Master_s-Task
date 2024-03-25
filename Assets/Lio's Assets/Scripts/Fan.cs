using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using Unity.Mathematics;

namespace Lio
{
    public class Fan : MonoBehaviour
    {
        public float speed;
        public bool begin;
        public float force1;
        public float force2;

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

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!rotation) return;
            GameObject go = collision.gameObject;
            Smog smog = go.GetComponent<Smog>();
            if (smog == null) return;
            smog.ResetLastTime();
            Rigidbody2D rd = go.GetComponent<Rigidbody2D>();
            Vector3 direction = transform.position - go.transform.position;
            direction = direction.normalized;

            rd.AddForce(direction * force1, ForceMode2D.Impulse);


            Vector3 buff = direction;
            direction.x = buff.y;
            direction.y = -buff.x;

            float des = Vector3.Distance(transform.position, go.transform.position);
            float rotationVel = speed * math.PI / 180;
            float velConst = rotationVel * des * force2;
            Vector3 vel = velConst * direction;
            rd.AddForce(vel, ForceMode2D.Impulse);
        }
    }
}
