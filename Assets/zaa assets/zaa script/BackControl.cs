using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zaaPro
{
    public class BackControl : MonoBehaviour
    {
        // Start is called before the first frame update
        public static BackControl instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

