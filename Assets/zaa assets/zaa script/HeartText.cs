using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace zaaPro
{
    public class HeartText : MonoBehaviour
    {
        // Start is called before the first frame update
        public TextMeshProUGUI text;

        // Update is called once per frame
        private void Start()
        {
            text=GetComponent<TextMeshProUGUI>();
        }
        void Update()
        {
            text.text = CWall.instance.health.ToString();
        }
    }
}

