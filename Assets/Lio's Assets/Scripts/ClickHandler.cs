using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class ClickHandler : MonoBehaviour
    {
        public float range;
        public Vector2 x;
        public Vector2 y;

        // Start is called before the first frame update
        void Start()
        {
            double i, j;
            for(i=x.x; i<x.y;i+=0.1f)
            {
                for(j=y.x;j<y.y;j+=0.1f)
                {

                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
