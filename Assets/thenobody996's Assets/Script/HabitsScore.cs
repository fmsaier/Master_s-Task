using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;

namespace Thenobody
{
    public class HabitsScore : MonoBehaviour
    {
        public static HabitsScore instance;
        public Action onEnd;

        [SerializeField] public float score;
        public int suancaicount;
        public int recaicolddown;
        public float colddown;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            score = 0;
            suancaicount = 0;
            colddown = 0;
        }
        public void ScoreUpdate(int enemytype)
        {
            switch(enemytype)
            {
                case 0:
                    Enemy();
                    break;
                case 1:
                    suancai();
                    break;
                case 2:
                    noodles(); 
                    break;
                case 3:
                    recai();
                    break;
            }    
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
            if(suancaicount > 0)
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
        private void Update()
        {
            if (colddown > 0)
                colddown -= Time.deltaTime;
            else if(colddown < 0)
                colddown = 0;
        }
    }
}