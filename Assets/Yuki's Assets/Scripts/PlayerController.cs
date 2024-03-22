using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class PlayerController : MonoBehaviour
    {
        [Header("本体")]
        private float inputX, inputY;
        public float moveSpeed;
        public float shootColdDown;
        private float coldDownTimeCounter;
        public int specialShotTimes;
        public int score;
        public int lives;

        [Header("子弹")]
        public GameObject bullet;
        public float bulletSpeed;
        public float speedFix;
        public float angleFix;

        private void Update()
        {
            if (coldDownTimeCounter > 0)
                coldDownTimeCounter -= Time.deltaTime;

            /*特殊射击*/
            if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.K)) && coldDownTimeCounter <= 0 && specialShotTimes > 0)
            {
                coldDownTimeCounter = shootColdDown;
                specialShotTimes--;
                for (int i = -4; i <= 4; i++)
                {
                    GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                    b.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, inputY * angleFix + i * 7.5f) * new Vector2(bulletSpeed + inputX * speedFix, 0);
                }
            }

            /*普通射击*/
            if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.J)) && coldDownTimeCounter <= 0)
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

            /*减速*/
            if(Input.GetKey(KeyCode.LeftShift))
                transform.Translate(new Vector2(inputX * moveSpeed/2 * Time.deltaTime, inputY * moveSpeed/2 * Time.deltaTime), relativeTo: Space.World);
            else
                transform.Translate(new Vector2(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime), relativeTo: Space.World);

        }
    }
}

