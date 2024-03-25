using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct SeyangCardConfig
{
    [field: SerializeField] public int CardIndex { get; private set; }
    [field: SerializeField] public Sprite CardSprite { get; private set; }

    public SeyangCardConfig(int cardIndex, Sprite cardSprite)
    {
        CardIndex = cardIndex;
        CardSprite = cardSprite;
    }
}

public class SeyangCardManager : MonoBehaviour
{
    [SerializeField] private SeyangCardController[] controllers;
    [SerializeField] private SeyangCardConfig[] configs;
    
    private SeyangCardController selectedController = null;
    private int cardTotalCount;
    private int cardCurrentCount;
    private void Start()
    {
        if (configs.Length != controllers.Length)
        {
            Debug.Log("你在做牛魔？");
            return;
        }

        cardTotalCount = controllers.Length;
        cardCurrentCount = cardTotalCount;

        for (int i = 0; i < 10; i++)
        {
            int index0 = Random.Range(0, configs.Length);
            int index1 = Random.Range(0, configs.Length);

            (configs[index0], configs[index1]) = (configs[index1], configs[index0]);
        }
        
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].onClick += OnClickCard;
            controllers[i].onClear += OnCardClear;
            controllers[i].SetConfig(configs[i].CardIndex,configs[i].CardSprite);
        }
    }

    private void OnClickCard(SeyangCardController controller)
    {
        if (selectedController == null)
        {
            selectedController = controller;
        }
        else
        {
            if (selectedController.CardTypeIndex == controller.CardTypeIndex)
            {
                selectedController.Clear();
                controller.Clear();
            }
            else
            {
                selectedController.HideContent();
                controller.HideContent();
            }
            selectedController = null;
        }
    }

    private void OnCardClear()
    {
        cardCurrentCount--;
        if (cardCurrentCount <= 0)
        {
            SeyangGameManager.Instance.OnGameOver(true);
        }
    }
}

