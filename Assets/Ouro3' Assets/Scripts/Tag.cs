using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ouro3
{
    public enum Tags
    {
        Acl,Bcl,Ccl,Dcl
    }

    public class Tag : MonoBehaviour
    {
        public Tags Mytag;
        private float Num = 100;
        public bool Restart;
        [SerializeField]private bool change;
        public int Health = 10;
        public int Defence;
        public Sprite[] Sprites;
        private SpriteRenderer Myrenderer;
        private int Count;

        public UnityEvent Death;

        // Start is called before the first frame update
        void Start()
        {
            Myrenderer = GetComponent<SpriteRenderer>();
            change = true;
        }

        // Update is called once per frame
        void Update()
        {
            Restart = AllControl.instance.restart;            
            if (Restart)
            {
                change = true;
            }
            if (change)
            {
                RandomDicider();
                change = false;
            }
            if(Health <= 0)
            {
                Death?.Invoke();
            }
        }

        private void RandomDicider()
        {
            Count = Random.Range(0,100);
            if(Count >=0 && Count <= 40 )
            {
                Mytag = Tags.Acl;
                Myrenderer.sprite = Sprites[0];
            }

            if( Count > 40 && Count <= 70 )
            {
                Mytag = Tags.Bcl;
                Myrenderer.sprite = Sprites[1];
            }

            if( Count > 70 && Count <= 90 )
            {
                Mytag = Tags.Ccl;
                Myrenderer.sprite = Sprites[2];
            }

            if( Count > 90 && Count <= 100 )
            {
                Mytag = Tags.Dcl;
                Myrenderer.sprite = Sprites[3];
            }

        }
    }
}

