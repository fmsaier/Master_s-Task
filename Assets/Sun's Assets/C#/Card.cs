using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sun
{
    public class Card : MonoBehaviour
    {
        public CardState cardState;
        public CardPattern cardPattern;
        public GameManager gameManager;
        // Start is called before the first frame update
        void Start()
        {
            cardState = CardState.Down;
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        private void OnMouseUp()
        {
            if (cardState.Equals(CardState.On)||cardState.Equals(CardState.Couple))
            {
                return;
            }

            if (gameManager.ReadyToCompareCards)
            {
                return;
            }
            OpenCard();
            gameManager.AddCardInCardComparision(this);
            gameManager.CompareCardInList();

        }

        void OpenCard()
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            cardState = CardState.On;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }

    public enum CardState
    { 
    On,Down,Couple
    }

    public enum CardPattern
    { 
    None,First,Second,Third,Forth,Fifth,Sixth
    }
}
