using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Yuki
{
    public class GameStart : MonoBehaviour
    {
        public Image[] image;
        private int currentImage = 1;

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void Start()
        {
            image = transform.GetComponentsInChildren<Image>();
        }

        private void Update()
        {
            if (image[currentImage].color.a < 1)
                image[currentImage].color = new Color(1, 1, 1, image[currentImage].color.a + 0.01f);
        }

        public void NextPage()
        {
            if (currentImage < image.Length - 2)
                currentImage++;
            else
                gameObject.SetActive(false);
        }
    }
}

