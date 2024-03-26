using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ouro3
{
    public class Status : MonoBehaviour
    {
        private GameObject player;
        private Tag playerTag;

        public Text HealthText;
        public Text DefenceText;
        public Text ActionText;
        public Text StayText;
        public Text LastText;

        private int health;
        private int defence;
        private float actionTime;
        private float stayTime;
        private float lastTime;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            playerTag = player.GetComponent<Tag>();
        }

        // Update is called once per frame
        void Update()
        {
            health = playerTag.Health;
            defence = playerTag.Defence;
            actionTime = AllControl.instance.timeCounter1;
            stayTime = AllControl.instance.timeCounter2;
            lastTime = AllControl.instance.timeCounter3;
            HealthText.text = health.ToString();
            DefenceText.text = defence.ToString();
            ActionText.text = actionTime.ToString();
            StayText.text = stayTime.ToString();
            LastText.text = lastTime.ToString();

        }
    }

}
