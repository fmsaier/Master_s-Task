using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ouro3
{
    public enum Checkers
    {
        AY, AN, BY, BN, CY, CN, DY, DN
    }
    public class Warning : MonoBehaviour
    {
        public int Num = 8;
        private int Count;
        public Checkers Checker;
        public TagChecker tagChecker;
        public bool Restart;
        public Sprite[] Sprites;
        private SpriteRenderer Myrenderer;
        void Start()
        {
            Restart = true;
            tagChecker = GetComponentInChildren<TagChecker>();
            Myrenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Restart)
            {
                RandomDicider();
                Restart = false;
                tagChecker.Checker = Checker;
            }
        }
        private void RandomDicider()
        {
            Count = Random.Range(0, Num - 1);
            if (Count == 0)
            {
                Checker = Checkers.AY;
            }

            if (Count == 1)
            {
                Checker = Checkers.AN;
            }

            if (Count == 2)
            {
                Checker = Checkers.BY;
            }

            if (Count == 3)
            {
                Checker = Checkers.BN;
            }

            if (Count == 4)
            {
                Checker = Checkers.CY;
            }

            if (Count == 5)
            {
                Checker = Checkers.CN;
            }

            if (Count == 6)
            {
                Checker = Checkers.DY;
            }

            if (Count == 7)
            {
                Checker = Checkers.DN;
            }
            Myrenderer.sprite = Sprites[Count];
        }
    }

}
