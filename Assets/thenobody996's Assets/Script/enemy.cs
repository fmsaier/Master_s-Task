using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Thenobody
{
    public class enemy : MonoBehaviour
    {
        Rigidbody2D rb;
        public float speed;
        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0,-speed);
        }
        public void Destory()
        {
            Destroy(this.gameObject);
        }
    }
}
