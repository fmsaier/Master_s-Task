using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ouro3
{
    
    public class TagChecker : MonoBehaviour
    {
        public Checkers Checker;
        [SerializeField]private Tag player;
        public float desTime = 2;
        private float timeCounter;

        private void Start()
        {
            timeCounter = desTime;
        }

        private void Update()
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
            {
                timeCounter = 0;
                DestroyBullet();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                player = other.gameObject.GetComponent<Tag>();
                StartCheck(player.Mytag, player);
            }

        }

        public void DestroyBullet()
        {
            Destroy(this.gameObject);
        }

        public void StartCheck(Tags tag,Tag player)
        {
            if(tag == Tags.Acl)
            {
                if(Checker == Checkers.Prevent)
                {
                    player.Defence+=2;
                }
                if(Checker == Checkers.Cancer)
                {
                    if(player.Defence > 4)
                    {
                        player.Defence-=4;
                    }
                    else
                    {
                        player.Health-= (4 - player.Defence);
                        player.Defence=0;   
                    }
                }
            }

            if (tag == Tags.Bcl)
            {
                if (Checker == Checkers.Prevent)
                {
                    player.Defence+=2;
                }
                if (Checker == Checkers.Cancer)
                {
                    if (player.Defence > 3)
                    {
                        player.Defence-=3;
                    }
                    else
                    {
                        player.Health -= (3 - player.Defence);
                        player.Defence=0;
                    }
                }
            }

            if (tag == Tags.Ccl)
            {
                if (Checker == Checkers.Prevent)
                {
                    player.Defence+=1;
                }
                if (Checker == Checkers.Cancer)
                {
                    if (player.Defence > 2)
                    {
                        player.Defence-=2;
                    }
                    else
                    {
                        player.Health -= (2 - player.Defence);
                        player.Defence=0;
                    }
                }
            }

            if (tag == Tags.Dcl)
            {
                if (Checker == Checkers.Prevent)
                {
                    player.Defence++;
                }
                if (Checker == Checkers.Cancer)
                {
                    if (player.Defence > 1)
                    {
                        player.Defence--;
                    }
                    else
                    {
                        player.Health--;
                    }
                }
            }
        }
    }
}
