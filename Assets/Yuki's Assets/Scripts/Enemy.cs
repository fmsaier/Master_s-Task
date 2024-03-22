using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D rb;

        public int hp;
        public float speed;
        public float initialAngle;
        public int score;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            rb.velocity = Quaternion.Euler(0, 0, initialAngle) * new Vector2(0, -speed);
        }
    }
}

