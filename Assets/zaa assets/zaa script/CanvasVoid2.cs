using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zaaPro;

namespace zaaPRo
{
    public class CanvasVoid2 : MonoBehaviour
    {
     public static CanvasVoid2 instance;
     public bool isVirus;
        private void Awake()
        {
            if(instance==null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            isVirus = false;
        }

        private void Update()
        {
            if (isVirus)
            {
                if(!Man.instance.isDie && VirusControl.instance.isTime)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    Man.instance.isDie = false;
                    VirusControl.instance.isTime = false;
                    isVirus = false;
                }
                if (Man.instance.isDie &&!VirusControl.instance.isTime)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    Man.instance.isDie = false;
                    VirusControl.instance.isTime = false;
                    isVirus = false;
                }
            }

        }
    }
}

