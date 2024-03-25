using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeyangGameManager : SeyangMonoSingleton<SeyangGameManager>
{
    protected override bool IsDontDestroyOnLoad => false;

    [SerializeField] private float totalDuration;
    [SerializeField] private TextMeshProUGUI countdownText;
    public bool IsGameStart { get; private set; }
    public float Timer { get; private set; }

    public void OnGameStart()
    {
        IsGameStart = true;
        Timer = totalDuration;
        
    }

    public void OnGameOver(bool result)
    {
        IsGameStart = false;
        if(result)
            SeyangUIManager.Instance.ShowGameWinPanel();
        else
            SeyangUIManager.Instance.ShowGameFailPanel();
    }

    private void Update()
    {
        if (IsGameStart)
        {
            Timer -= Time.deltaTime;
            countdownText.text = $"剩余时间:{(int)Timer}";
            if (Timer <= 0)
            {
                OnGameOver(false);
            }
        }
    }
}

