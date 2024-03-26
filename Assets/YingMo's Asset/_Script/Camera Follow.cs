using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace YingMo
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject Player;

        private void Update()
        {
            transform.position = new Vector3(Player.transform.position.x + 7, Player.transform.position.y, -10);
        }
    }
}
