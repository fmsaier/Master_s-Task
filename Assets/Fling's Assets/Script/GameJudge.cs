using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Merryfling
{
    public class GameJudge : MonoBehaviour
    {
        [Header("新手相关")]
        public GameObject newPanel;         // 新手教程仪表盘
        [Header("平台相关")]
        public float salt;          // 平台偏移量
        public GameObject Flat;         // 目标
        public GameObject Sea;          // 海,催促玩家往上
        public GameObject player;           // 玩家
        [Header("进度相关")]
        public float SeaUpTime;         // 海平面上升到Flat所用时间
        [Header("文本相关")]
        public Text playerHeight;
        public Text fromSea;
        public Text fromFlat;
        [Header("通关相关")]
        public GameObject WinPanel;
        public GameObject LosePanel;
        [Header("暂停相关")]
        public Text pauseText;
        public GameObject pausePanel;
        public GameObject pauseButton;

        private void Start()
        {
            Time.timeScale = 0;
            WinPanel.SetActive(false);
            LosePanel.SetActive(false);
            salt = Random.Range(-11f, 11f);
            New();
        }

        private void Update()
        {
            FlashPos();
            FlashText();
            GameJudgement();
        }

        private void New()
        {
            newPanel.SetActive(true);
        }

        private void FlashPos()
        {
            if(player)
            {
                //??:为什么赋值只能v3,读取可以xyz
                //HASDO:这里Flat不能一直动,选定之后就固定
                Flat.transform.position = new Vector3(player.transform.position.x + salt, 100f, 0);
                Sea.transform.position = new Vector3(player.transform.position.x, Sea.transform.position.y + ((100 + 9.5f) / SeaUpTime) * Time.deltaTime, 0);//!!:上次忘记了timedeltatime,跑得飞快//TODO:考虑是否插值,即越近越快
            }
        }

        private void FlashText()
        {
            if(player)
            {
                playerHeight.text = "当前" + player.transform.position.y + "米";
                fromSea.text = "距离海平面" + (player.transform.position.y - Sea.transform.position.y-8f) + "米";
                fromFlat.text = "距离平台" + (Flat.transform.position.y - player.transform.position.y) + "米";
            }
        }

        private void GameJudgement()
        {
            if(!player&& !LosePanel.activeSelf)
            {
                Debug.Log("死");
                Time.timeScale = 0f;
                LosePanel.SetActive(true);
            }
            if (player&&player.transform.position.y >= 100f)
            {
                Debug.Log("胜利");
                Time.timeScale = 0f;
                WinPanel.SetActive(true);
            }
        }

        public void RePlay()
        {
            SceneManager.LoadScene("FlingScene");
        }

        public void CloseNewPanel()
        {
            newPanel.SetActive(false);
        }

        public void StartGame()
        {
            newPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            if(Time.timeScale != 0f)
            {
                pausePanel.SetActive(true);
                pauseButton.transform.GetChild(0).GetComponent<Text>().text = "继续";
                pauseText.text = "停";
                Time.timeScale = 0f;
            }
            else
            {
                StartCoroutine(ResumeGame());
            }
        }

        IEnumerator ResumeGame()
        {
            pauseButton.transform.GetChild(0).GetComponent<Text>().text = "暂停";
            pauseButton.gameObject.GetComponent<Button>().interactable = false;

            for (int i = 3; i >= 1; i--)
            {
                pauseText.text = i.ToString();
                yield return new WaitForSecondsRealtime(1f);
            }
            pauseText.text = "0";
            pausePanel.SetActive(false);
            pauseButton.gameObject.GetComponent<Button>().interactable = true;
            Time.timeScale = 1f;
        }

        public void BackMap()
        {
            SceneManager.LoadScene(1);
        }
    }
}