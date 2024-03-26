using Ouro3;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Ouro3
{
    public class Finish : MonoBehaviour
    {
        public GameObject player;
        public GameObject FinishPenal;
        public Tag playerTag;
        public int Defence;
        public Text Num;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            playerTag = player.GetComponent<Tag>();
        }

        // Update is called once per frame
        void Update()
        {
            Defence = playerTag.Defence;
            Num.text = Defence.ToString();
        }

        public void Open()
        {
            Time.timeScale = 0;
            FinishPenal.gameObject.SetActive(true);
        }
    }

}