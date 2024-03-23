using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject handle;
        public bool isShootPressed;
        public bool isSkillPressed;

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
            if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.K) || isSkillPressed) && coldDownTimeCounter <= 0 && specialShotTimes > 0)
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
            if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.J) || isShootPressed) && coldDownTimeCounter <= 0)
            {
                coldDownTimeCounter = shootColdDown;
                
                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, inputY * angleFix) * new Vector2(bulletSpeed + inputX * speedFix, 0);
            }

            isShootPressed = false;
            isSkillPressed = false;
        }

        private void FixedUpdate()
        {
            inputX = handle == null ? Input.GetAxis("Horizontal") : handle.transform.localPosition.x / 128;
            inputY = handle == null ? Input.GetAxis("Vertical") : handle.transform.localPosition.y / 128;

            transform.Translate(new Vector2(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime), relativeTo: Space.World);
        }

        public void Shoot() => isShootPressed = true;

        public void Skill() => isSkillPressed = true;
    }
}

