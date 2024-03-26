using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YingMo
{
    public class PuaseManager : MonoBehaviour
    {
        public GameObject PuaseUI;
        public GameObject GuideUI;

        public void Puase()
        {
            PuaseUI.SetActive(true);
            Time.timeScale = 0;
        }

        public void Continue()
        {
            PuaseUI.SetActive(false);
            Time.timeScale = 1;
        }

        public void CloseGuide()
        {
            GuideUI.SetActive(false);
            Time.timeScale = 1;
        }

        public void ReStart()
        {
            SceneManager.LoadScene("PlayScene");
        }

        public void BackToMain()
        {
            SceneManager.LoadScene("Bowuguan");
        }
    }
}
