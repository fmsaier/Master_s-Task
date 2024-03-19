using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace XLZXLZ
{
    public class PlayerHead : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] heads;

        private Image img;

        private void Awake()
        {
            img = GetComponent<Image>();    
        }

        void Update()
        {
            var val = Score.instance.currentScore / Score.instance.targetScore;

            if(val >= 0.5f && val < 0.75f)
            {
                img.sprite = heads[1];
            }
            else if (val >= 0.75f)
            {
                img.sprite = heads[2];
            }
            else
            {
                img.sprite = heads[0];
            }
        }
    }
}
