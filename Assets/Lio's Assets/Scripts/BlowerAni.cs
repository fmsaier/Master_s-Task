using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;

namespace Lio
{
    public class BlowerAni : MonoBehaviour
    {
        public Blower blower;
        public GameObject wind;
        public GameObject open;
        public GameObject close;
        // Start is called before the first frame update
        void Start()
        {
            return;
        }

        // Update is called once per frame
        void Update()
        {
            if(blower.runing)
            {
                wind.SetActive(true);
                close.SetActive(false);
                open.SetActive(true);
            }
            else
            {
                wind.SetActive(false);
                close.SetActive(true);
                open.SetActive(false);
            }
        }
    }
}
