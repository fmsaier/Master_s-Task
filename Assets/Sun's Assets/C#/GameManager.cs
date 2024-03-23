using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Sun
{
    public class GameManager : MonoBehaviour
    {
        [Header("�ȶԿ��Ƶ��嵥")]
        public List<Card> cardComparision;
        [Header("��Ƭ�����嵥")]
        public List<CardPattern> cardsToBePutIn;

        public Transform[] positions;

        // Start is called before the first frame update
        void Start()
        {
            //SetUpCardToBePutIn();
            //AddNewCard(CardPattern.First);
            GenerateRandomCards();
        }
        void AddNewCard(CardPattern cardPattern,int positionIndex)
        {
            GameObject card = Instantiate(Resources.Load<GameObject>("Prafabs/card"));
            card.GetComponent<Card>().cardPattern = cardPattern;
            card.name = "card_" + cardPattern.ToString();
            card.transform.position = positions[positionIndex].position;

            GameObject graphic = Instantiate(Resources.Load<GameObject>("Prafabs/Picture"));
            graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CardFront/" + cardPattern.ToString());
            graphic.transform.SetParent(card.transform);//����Ƶ������
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//���û�ɫ����
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);//˳��y����ת180 ����ʱ�������ҵߵ�
        }

        void GenerateRandomCards()//����
        {
            int positionIndex = 0;
            for (int i=0;i<2;i++)
            {
                SetUpCardToBePutIn();//׼������
                int maxRandomNumber = cardsToBePutIn.Count;//������

                for (int j = 0; j < maxRandomNumber; maxRandomNumber--)
                {
                    int randomNumber = UnityEngine.Random.Range(0, maxRandomNumber);//���
                    AddNewCard(cardsToBePutIn[randomNumber], positionIndex);
                    cardsToBePutIn.RemoveAt(randomNumber);
                    positionIndex++;
                }
            }
        }

        void SetUpCardToBePutIn()//Enumתlist
        {
            Array array = Enum.GetValues(typeof(CardPattern));
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPattern)item);
            }
            cardsToBePutIn.RemoveAt(0);
        }

        public void AddCardInCardComparision(Card card)
        {
            cardComparision.Add(card);
        }
        public bool ReadyToCompareCards
        {
            get
            {
                if (cardComparision.Count == 2)
                    return true;
                else
                    return false;
            }
        }

        public void CompareCardInList()
        {
            if (ReadyToCompareCards)
            {
                //Debug.Log("���ԱȶԿ�����");
                if (cardComparision[0].cardPattern == cardComparision[1].cardPattern)
                {
                    Debug.Log("������һ��");
                    foreach (var card in cardComparision)
                    {
                        card.cardState = CardState.Couple;
                    }
                    ClearCardComparison();
                }
                else
                {
                    Debug.Log("�����Ʋ�һ��");
                    StartCoroutine(MissMatchCards());
                }
            }
        }

        void ClearCardComparison()
        {
            cardComparision.Clear();
        }

        void TurnBackCards()
        {
            foreach (var card in cardComparision)
            {
                card.gameObject.transform.eulerAngles = Vector3.zero;
                card.cardState = CardState.Down;
            }
        }
        IEnumerator MissMatchCards()
        {
            yield return new WaitForSeconds(0.5f);
            TurnBackCards();
            ClearCardComparison();
        }
    }
}
