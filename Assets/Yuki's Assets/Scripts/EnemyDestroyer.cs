using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class EnemyDestroyer : MonoBehaviour
    {
        private PlayerController player;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            player.lives--;
        }
    }
}

