using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace zaaPro
{
    public class CanvasVoid1 : MonoBehaviour
    {
        public static CanvasVoid1 instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }
    }

}

