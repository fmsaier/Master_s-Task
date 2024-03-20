using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using Unity.VisualScripting;

namespace Lio
{
    public class Smog : MonoBehaviour
    {
        [Header("Set")]
        public float range;
        public float timeInterval;
        public float life;

        private Animator ani;
        private Vector3 lastPoint;
        private float lastTime;
        private bool isDisapearing;
        // Start is called before the first frame update
        void Start()
        {
            ani = GetComponent<Animator>();
            lastPoint = transform.position;
            lastTime = Time.time;
            isDisapearing = false;

            Destroy(gameObject, life);
        }

        // Update is called once per frame
        void Update()
        {
            if (isDisapearing) return;
            if (Time.time - lastTime > timeInterval)
            {
                lastTime = Time.time;
                if (Vector3.Distance(lastPoint, transform.position) < range)
                {
                    isDisapearing = true;
                    ani.Play("Disappear");
                }
                else
                {
                    lastPoint = transform.position;
                }
            }
        }

        //用于动画事件
        public void AniFunc()
        {
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
