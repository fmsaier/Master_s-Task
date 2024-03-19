using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class PlayerController : MonoBehaviour
    {
        [Header("±¾Ìå")]
        private float inputX, inputY;
        public float moveSpeed;
        public float shootColdDown;
        private float coldDownTimeCounter;

        [Header("×Óµ¯")]
        public GameObject bullet;
        public float bulletSpeed;
        public float speedFix;
        public float angleFix;

        private void Update()
        {
            if (coldDownTimeCounter > 0)
                coldDownTimeCounter -= Time.deltaTime;

            if((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.J)) && coldDownTimeCounter <= 0)
            {
                coldDownTimeCounter = shootColdDown;
                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, inputY * angleFix) * new Vector2(bulletSpeed + inputX * speedFix, 0);
            }
        }

        private void FixedUpdate()
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            if(Input.GetKey(KeyCode.LeftShift))
                transform.Translate(new Vector2(inputX * moveSpeed/2 * Time.deltaTime, inputY * moveSpeed/2 * Time.deltaTime), relativeTo: Space.World);
            else
                transform.Translate(new Vector2(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime), relativeTo: Space.World);

        }
    }
}

