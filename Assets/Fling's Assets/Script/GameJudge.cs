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
        [Header("�������")]
        public GameObject newPanel;         // ���ֽ̳��Ǳ���
        [Header("ƽ̨���")]
        public float salt;          // ƽ̨ƫ����
        public GameObject Flat;         // Ŀ��
        public GameObject Sea;          // ��,�ߴ��������
        public GameObject player;           // ���
        [Header("�������")]
        public float SeaUpTime;         // ��ƽ��������Flat����ʱ��
        [Header("�ı����")]
        public Text playerHeight;
        public Text fromSea;
        public Text fromFlat;
        [Header("ͨ�����")]
        public GameObject WinPanel;
        public GameObject LosePanel;
        [Header("��ͣ���")]
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
                //??:Ϊʲô��ֵֻ��v3,��ȡ����xyz
                //HASDO:����Flat����һֱ��,ѡ��֮��͹̶�
                Flat.transform.position = new Vector3(player.transform.position.x + salt, 100f, 0);
                Sea.transform.position = new Vector3(player.transform.position.x, Sea.transform.position.y + ((100 + 9.5f) / SeaUpTime) * Time.deltaTime, 0);//!!:�ϴ�������timedeltatime,�ܵ÷ɿ�//TODO:�����Ƿ��ֵ,��Խ��Խ��
            }
        }

        private void FlashText()
        {
            if(player)
            {
                playerHeight.text = "��ǰ" + player.transform.position.y + "��";
                fromSea.text = "���뺣ƽ��" + (player.transform.position.y - Sea.transform.position.y-8f) + "��";
                fromFlat.text = "����ƽ̨" + (Flat.transform.position.y - player.transform.position.y) + "��";
            }
        }

        private void GameJudgement()
        {
            if(!player&& !LosePanel.activeSelf)
            {
                Debug.Log("��");
                Time.timeScale = 0f;
                LosePanel.SetActive(true);
            }
            if (player&&player.transform.position.y >= 100f)
            {
                Debug.Log("ʤ��");
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
                pauseButton.transform.GetChild(0).GetComponent<Text>().text = "����";
                pauseText.text = "ͣ";
                Time.timeScale = 0f;
            }
            else
            {
                StartCoroutine(ResumeGame());
            }
        }

        IEnumerator ResumeGame()
        {
            pauseButton.transform.GetChild(0).GetComponent<Text>().text = "��ͣ";
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