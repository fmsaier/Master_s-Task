using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class PlayerController : MonoBehaviour
    {
        private float inputX, inputY;
        private float moveAngle;
        public float moveSpeed;

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

