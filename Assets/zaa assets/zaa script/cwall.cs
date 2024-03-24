using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace zaaPro
{
    public class CWall : MonoBehaviour
    {
        // Start is called before the first frame update
        public static CWall instance;
        public int Health;
        public int health
        {
            get
            {
                return Health;
            }
            set
            {
                if(value<=0)
                {
                    value = 0;
                }
                Health = value;
            }
        }
        void Awake()
        {
           if(instance==null)
           {
                instance = this;
           }
        }

        // Update is called once per frame
        private void Start()
        {
            health = 10;
        }
    }
}

