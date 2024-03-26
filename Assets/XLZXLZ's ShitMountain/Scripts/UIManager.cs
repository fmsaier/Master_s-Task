using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XLZXLZ
{
    public class UIManager : MonoBehaviour
    {
        public void ResetGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void ReturnMenu()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);
        }
        public void NextLevel()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Lio's Scene");
        }
    }
}
