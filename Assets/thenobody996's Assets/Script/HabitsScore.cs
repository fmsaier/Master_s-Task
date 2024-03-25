using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Thenobody
{
    public class HabitsScore : MonoBehaviour
    {
        [SerializeField] public int score;
        public int suancaicount;
        public int recaicolddown;
        public float colddown;
        private void Start()
        {
            score = 0;
            suancaicount = 0;
            colddown = 0;
        }

        public void Enemy()
        {
            score += 1;
        }
        public void suancai()
        {
            suancaicount++;
            if (suancaicount < 5)
                score += 3;
            else
            {
                score -= 20;
                suancaicount = 0;
            }
        }
        public void noodles()
        {
            score += 5;
            suancaicount--;
        }
        public void recai()
        {
            if (colddown < 0.05f)
            {
                score += 10;
            }
            else
            {
                score -= 30;
            }
            colddown = recaicolddown;
        }
    }
}