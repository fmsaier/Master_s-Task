using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ouro3
{
    public enum Tags
    {
        Acl,Bcl,Ccl,Dcl
    }

    public class Tag : MonoBehaviour
    {
        public Tags Mytag;
        public int Num = 4;
        public bool Restart;
        public int Health = 10;
        public int Defence;
        public Sprite[] Sprites;
        private SpriteRenderer Myrenderer;
        private int Count;


        // Start is called before the first frame update
        void Start()
        {
            Restart = true;
            Myrenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Restart)
            {
                RandomDicider();
                Restart = false;
            }
        }

        private void RandomDicider()
        {
            Count = Random.Range(0,Num-1);
            if(Count ==  0 )
            {
                Mytag = Tags.Acl;
            }

            if( Count == 1 )
            {
                Mytag = Tags.Bcl;
            }

            if( Count == 2 )
            {
                Mytag = Tags.Ccl;
            }

            if( Count == 3 )
            {
                Mytag = Tags.Dcl;
            }
            Myrenderer.sprite = Sprites[Count];
        }
    }
}

