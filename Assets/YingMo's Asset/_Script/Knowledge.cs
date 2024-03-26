using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YingMo;

namespace YingMo

{
    public class Knowledge : MonoBehaviour
    {
        public PlayerController playerController;
        public KnowledgeData data;
        public GameObject UI;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Time.timeScale = 0;
                UI.SetActive(true);
                Text text = UI.transform.GetChild(1).GetComponent<Text>();
                text.text = data.knowledge;
                playerController.AddHealth();
                Destroy(gameObject);
            }
        }
    }
}
