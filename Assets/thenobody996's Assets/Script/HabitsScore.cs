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

        public Text scoreText;
        public Text FinalScoreText;
        public Text now;
        public Text Tips0;
        public Text Tips1;
        public Text Tips2;


        public float GameTime;
        public float timenow;
        public int texttime;

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
            timenow = GameTime;
            Tips0.enabled = true;
            Tips1.enabled = false;
            Tips2.enabled = false;
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
            scoreText.text = score.ToString();
        }
        public void Enemy()
        {
            score += 1;
        }
        public void Punish()
        {
            score -= 1;
            scoreText.text = score.ToString();
        }
        public void suancai()
        {
            suancaicount++;
            if (suancaicount < 5)
                score += 3;
            else
            {
                score -= 20;
                suancaicount = 3;
                Tips0.enabled = false;
                Tips1.enabled = true;
                Tips2.enabled = false;
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
                Tips0.enabled = false;
                Tips1.enabled = false;
                Tips2.enabled = true;
            }
            suancaicount--;
            colddown = recaicolddown;
        }
        private void Update()
        {
            if (colddown > 0)
                colddown -= Time.deltaTime;
            else if(colddown < 0)
                colddown = 0;

            if(timenow > 0)
            {
                timenow -= Time.deltaTime;
                texttime = (int)timenow;
                now.text = texttime.ToString();
            }
            else if(timenow < 0)
            {
                timenow = 0;
                FinalScoreText.text = score.ToString();
                onEnd?.Invoke();
            }
        }
    }
}