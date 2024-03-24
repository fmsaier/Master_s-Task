using UnityEngine;

namespace Merryfling
{
    public class CameraControler : MonoBehaviour
    {
        [Header("¸úËæÏà¹Ø")]
        public GameObject player;

        private void Update()
        {
            if (player)
            {
                gameObject.transform.position = player.transform.position;
            }
        }
    }
}
