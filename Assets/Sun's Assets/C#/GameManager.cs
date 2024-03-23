using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sun
{
    public class GameManager : MonoBehaviour
    {
        [Header("比对卡牌的清单")]
        public List<Card> cardComparision;

        // Start is called before the first frame update
        void Start()
        {

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
            yield return new WaitForSeconds(1.5f);
            TurnBackCards();
            ClearCardComparison();
        }
    }
}
