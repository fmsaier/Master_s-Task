using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class Trigger : MonoBehaviour
    {
        public GameObject next;
        public int num;
        public bool dontDes;

        private int count;
        // Start is called before the first frame update
        void Start()
        {
            next.SetActive(false);
            count = 0;
            return;
        }

        // Update is called once per frame
        void Update()
        {
            return;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject go = collision.gameObject;
            if(go.GetComponent<Smog>()!=null)
            {
                count++;
            }
            if(count>=num)
            {
                next.SetActive(true);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!dontDes) return;
            GameObject go = collision.gameObject;
            Smog smog = go.GetComponent<Smog>();
            if (smog == null) return;
            smog.ResetLastTime();
        }
    }
}
