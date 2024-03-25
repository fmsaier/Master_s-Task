using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fu_x.i
{
    public class GuangyuanCanvas : MonoBehaviour
    {
        public static GuangyuanCanvas Instance { get; private set; }

        public GameObject background;
        public GameObject start;
        public GameObject intro;
        public GameObject move;
        public GameObject gameStart;
        public GameObject gameOver;
        public GameObject victory;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void Guangyuan_Start()
        {
            start.gameObject.SetActive(false);
            intro.gameObject.SetActive(true);
        }

        public void Guangyuan_Move()
        {
            var newX = move.transform.position.x - 1920;
            move.transform.DOMoveX(newX, 1.5f).SetEase(Ease.InOutBack);
        }

        public void Guangyuan_GameStart()
        {
            intro.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
            gameStart.gameObject.SetActive(true);
            Manager.Instance.GameStart();
            StartCoroutine(nameof(GameStartFade),1f);
        }

        private IEnumerator GameStartFade()
        {
            var trans = gameStart.transform;
            var newY = trans.position.y - 400f;
            gameStart.transform.DOMoveY(newY, 0.3f);
            yield return new WaitForSeconds(1.8f);
            newY = trans.position.y + 400f;
            gameStart.transform.DOMoveY(newY, 0.3f);
        }
        
        public void Guangyuan_GameOver()
        {
            SceneManager.LoadScene(1);
        }
    }
}