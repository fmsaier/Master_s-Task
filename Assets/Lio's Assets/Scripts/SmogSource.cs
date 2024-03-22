using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class SmogSource : MonoBehaviour
    {
        [Header("Set")]
        public float timeInterval;
        public int number;

        [Header("Ref")]
        public GameObject smog;
        public GameObject p1;
        public GameObject p2;

        private float lastTime;

        // Start is called before the first frame update
        void Start()
        {
            lastTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - lastTime > timeInterval)
            {
                lastTime = Time.time;
                for(int i=0;i<number;i++)
                {
                    Vector3 pos = new(0, 0, 0);
                    pos.x = Random.Range(p1.transform.position.x, p2.transform.position.x);
                    pos.y = Random.Range(p1.transform.position.y, p2.transform.position.y);
                    Instantiate(smog, pos, Quaternion.identity);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(new Vector3(p1.transform.position.x, p1.transform.position.y, 0), new Vector3(p1.transform.position.x, p2.transform.position.y, 0));
            Gizmos.DrawLine(new Vector3(p1.transform.position.x, p1.transform.position.y, 0), new Vector3(p2.transform.position.x, p1.transform.position.y, 0));
            Gizmos.DrawLine(new Vector3(p2.transform.position.x, p2.transform.position.y, 0), new Vector3(p2.transform.position.x, p1.transform.position.y, 0));
            Gizmos.DrawLine(new Vector3(p2.transform.position.x, p2.transform.position.y, 0), new Vector3(p1.transform.position.x, p2.transform.position.y, 0));
        }
    }
}
