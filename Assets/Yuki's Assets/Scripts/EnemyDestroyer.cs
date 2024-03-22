using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class EnemyDestroyer : MonoBehaviour
    {
        private PlayerController player;
        private UIManager uiManager;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            player.lives--;
            if (player.lives <= 0)
                uiManager.GameOver();
        }
    }
}

