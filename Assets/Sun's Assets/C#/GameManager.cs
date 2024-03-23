using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Sun
{
    public class GameManager : MonoBehaviour
    {
        [Header("比对卡牌的清单")]
        public List<Card> cardComparision;
        [Header("卡片种类清单")]
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
            graphic.transform.SetParent(card.transform);//变成牌的子物件
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//设置花色坐标
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);//顺着y轴旋转180 翻牌时不会左右颠倒
        }

        void GenerateRandomCards()//发牌
        {
            int positionIndex = 0;
            for (int i=0;i<2;i++)
            {
                SetUpCardToBePutIn();//准备卡牌
                int maxRandomNumber = cardsToBePutIn.Count;//卡牌数

                for (int j = 0; j < maxRandomNumber; maxRandomNumber--)
                {
                    int randomNumber = UnityEngine.Random.Range(0, maxRandomNumber);//随机
                    AddNewCard(cardsToBePutIn[randomNumber], positionIndex);
                    cardsToBePutIn.RemoveAt(randomNumber);
                    positionIndex++;
                }
            }
        }

        void SetUpCardToBePutIn()//Enum转list
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
                //Debug.Log("可以比对卡牌了");
                if (cardComparision[0].cardPattern == cardComparision[1].cardPattern)
                {
                    Debug.Log("两张牌一样");
                    foreach (var card in cardComparision)
                    {
                        card.cardState = CardState.Couple;
                    }
                    ClearCardComparison();
                }
                else
                {
                    Debug.Log("两张牌不一样");
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
