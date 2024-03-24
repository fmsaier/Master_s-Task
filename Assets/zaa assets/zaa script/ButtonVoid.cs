using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using zaaPRo;
using UnityEngine.SceneManagement;


namespace zaaPro
{
    public class Buttonvoid : MonoBehaviour
    {
        private int PicNum;
        public int picNum
        {
            get
            {
                return PicNum;
            }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                if (value >= 2)
                {
                    value = 2;
                }
                PicNum = value;
            }
        }

        private int masNum;

        private int num1, num2, num3;

        private bool isChange = true, isReact;

        public bool isKnow1, isKnow2, isKnow3;

        public Button button;

        private GameObject childObject;

        public static Buttonvoid instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            picNum = 0;
            masNum = 0;
            num1 = 0;
            num2 = 0;
            num3 = 0;
            isChange = true;
            isReact = true;
            isKnow1 = true;
            isKnow2 = true;
            isKnow3 = true;


        }

        private void Update()
        {
            if (masNum == 3 && isChange)
            {
                CanvasVoid1.instance.transform.GetChild(7).gameObject.SetActive(true);
                isChange = false;
            }
        }
        public void Left()
        {
            picNum -= 1;
            CanvasVoid.instance.transform.GetChild(picNum).gameObject.SetActive(true);
            CanvasVoid.instance.transform.GetChild(picNum + 1).gameObject.SetActive(false);
        }

        public void Right()
        {
            if (picNum == 2)
            {

                BackControl.instance.transform.GetChild(0).DOMove(new Vector3(-14.4228f, 0f, 0f), 1f).SetEase(Ease.InOutExpo);
                BackControl.instance.transform.GetChild(1).DOMove(new Vector3(14.4105f, 0f, 0f), 1f).SetEase(Ease.InOutExpo);
                CanvasVoid.instance.transform.gameObject.SetActive(false);
                GameObject Canvas1 = GameObject.Find("Canvas1");
                Animator animator = Canvas1.GetComponent<Animator>();
                animator.SetTrigger("isMascot");
                StartCoroutine(WaitToOpen());



            }
            else
            {
                picNum += 1;
                CanvasVoid.instance.transform.GetChild(picNum).gameObject.SetActive(true);
                CanvasVoid.instance.transform.GetChild(picNum - 1).gameObject.SetActive(false);
            }

        }

        public void MasLeft()
        {
            if (isReact)
            {
                CanvasVoid1.instance.transform.GetChild(4).gameObject.SetActive(true);
                CanvasVoid1.instance.transform.GetChild(4).DOScale(new Vector3(9f, 2.4f, 0f), 0.5f).SetEase(Ease.OutCubic);
                isReact = false;
            }
        }

        public void MasMiddle()
        {
            if (isReact)
            {
                CanvasVoid1.instance.transform.GetChild(5).gameObject.SetActive(true);
                CanvasVoid1.instance.transform.GetChild(5).DOScale(new Vector3(9f, 2.4f, 0f), 0.5f).SetEase(Ease.OutCubic);
                isReact = false;
            }

        }

        public void MasRight()
        {
            if (isReact)
            {
                CanvasVoid1.instance.transform.GetChild(6).gameObject.SetActive(true);
                CanvasVoid1.instance.transform.GetChild(6).DOScale(new Vector3(9f, 2.4f, 0f), 0.5f).SetEase(Ease.OutCubic);
                isReact = false;
            }

        }

        public void MasLeftClose()
        {
            if (num1 < 1)
            {
                masNum++;
                num1 += 1;
            }
            CanvasVoid1.instance.transform.GetChild(4).DOScale(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InCubic);
            StartCoroutine(WaitToTrue());

        }

        public void MasMiddleClose()
        {
            if (num2 < 1)
            {
                masNum++;
                num2 += 1;
            }
            CanvasVoid1.instance.transform.GetChild(5).DOScale(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InCubic);
            StartCoroutine(WaitToTrue());
        }

        public void MasRightClose()
        {
            if (num3 < 1)
            {
                masNum++;
                num3 += 1;
            }
            CanvasVoid1.instance.transform.GetChild(6).DOScale(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InCubic);
            StartCoroutine(WaitToTrue());
        }

        public void StartGame()
        {
            button=button.GetComponent<Button>();
            button.interactable = false;
            Animator animator = CanvasVoid1.instance.GetComponent<Animator>();
            animator.SetTrigger("isPanda");
            StartCoroutine(WaitToShow());
        }

        public void Skip()
        {
            StartGame();
            BackControl.instance.transform.GetChild(0).gameObject.SetActive(false);
            BackControl.instance.transform.GetChild(1).gameObject.SetActive(false);
            CanvasVoid.instance.transform.gameObject.SetActive(false);

        }

        public void Next()
        {
            if(VirusControl.instance.isTime)
            {
                childObject = BackControl.instance.transform.GetChild(9).gameObject;
            }
            if (!VirusControl.instance.isTime)
            {
                childObject = BackControl.instance.transform.GetChild(8).gameObject;
            }

            if(childObject!=null)
            {
                childObject.layer = 10;
            }
          
            StartCoroutine(ChangeScene());
        }

        public void Close1()
        {
            CanvasVoid2.instance.transform.GetChild(3).gameObject.SetActive(false);
            Time.timeScale = 1;
            
        }

        public void Close2()
        {
            CanvasVoid2.instance.transform.GetChild(4).gameObject.SetActive(false);
            Time.timeScale = 1;
            
        }

        public void Close3()
        {
            CanvasVoid2.instance.transform.GetChild(5).gameObject.SetActive(false);
            Time.timeScale = 1;
          
        }
        IEnumerator WaitToOpen()
        {
            GameObject Canvas1 = GameObject.Find("Canvas1");
            yield return new WaitForSecondsRealtime(0.8f);
            BackControl.instance.transform.GetChild(2).DOMove(new Vector3(0f, 2.44f, 0f), 1f).SetEase(Ease.OutBounce);
            BackControl.instance.transform.GetChild(3).DOMove(new Vector3(0f, -2.6f, 0f), 1f).SetEase(Ease.OutBounce);
            yield return new WaitForSecondsRealtime(1f);
            for (int i = 0; i < 4; i++)
            {
                Canvas1.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        IEnumerator WaitToShow()
        {
            yield return new WaitForSecondsRealtime(1f);

            for (int i = 0; i < CanvasVoid1.instance.transform.childCount - 1; i++)
            {
                CanvasVoid1.instance.transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 2; i <= 3; i++)
            {
                BackControl.instance.transform.GetChild(i).gameObject.SetActive(false);

            }
            for (int i = 4; i <= 8; i++)
            {
                BackControl.instance.transform.GetChild(i).gameObject.SetActive(true);

            }
            CanvasVoid2.instance.transform.GetChild(0).gameObject.SetActive(true);
            CanvasVoid2.instance.isVirus = true;

        }

        IEnumerator WaitToTrue()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            isReact = true;

        }


        IEnumerator ChangeScene()
        {
            Animator animator = CanvasVoid1.instance.GetComponent<Animator>();
            animator.SetTrigger("isPanda");
            CanvasVoid2.instance.transform.gameObject.SetActive(false);
            for(int i=0;i<BackControl.instance.transform.childCount -1;i++)
            {
                BackControl.instance.transform.GetChild(i).gameObject.SetActive(false);
            }
        
            yield return new WaitForSecondsRealtime(2.5f);
            SceneManager.LoadSceneAsync("Guangyuan1");

        }

    }

}
