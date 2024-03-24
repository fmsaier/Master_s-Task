using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ouro3
{
    
    public class TagChecker : MonoBehaviour
    {
        public bool Restart;
        public Checkers Checker;
        private Tag player;
        void Start()
        {
            Restart = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (Restart)
            {
                Restart = false;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                player = other.gameObject.GetComponent<Tag>();
                StartCheck(player.Mytag, player);
            }

        }

        public void StartCheck(Tags tag,Tag player)
        {
            if(tag == Tags.Acl)
            {
                if(Checker == Checkers.AY)
                {
                    player.Defence++;
                }
                if(Checker == Checkers.AN)
                {
                    if(player.Defence > 0)
                    {
                        player.Defence--;
                    }
                    else
                    {
                        player.Health--;
                    }
                }
            }

            if (tag == Tags.Bcl)
            {
                if (Checker == Checkers.BY)
                {
                    player.Defence++;
                }
                if (Checker == Checkers.BN)
                {
                    if (player.Defence > 0)
                    {
                        player.Defence--;
                    }
                    else
                    {
                        player.Health--;
                    }
                }
            }

            if (tag == Tags.Ccl)
            {
                if (Checker == Checkers.CY)
                {
                    player.Defence++;
                }
                if (Checker == Checkers.CN)
                {
                    if (player.Defence > 0)
                    {
                        player.Defence--;
                    }
                    else
                    {
                        player.Health--;
                    }
                }
            }

            if (tag == Tags.Dcl)
            {
                if (Checker == Checkers.DY)
                {
                    player.Defence++;
                }
                if (Checker == Checkers.DN)
                {
                    if (player.Defence > 0)
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
