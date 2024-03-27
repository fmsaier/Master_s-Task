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
                gameObject.transform.position =new Vector3( player.transform.position.x, player.transform.position.y,-10f);
            }
        }
    }
}
