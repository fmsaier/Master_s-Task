using System;
using System.Collections.Generic;
using UnityEngine;

public class SeyangUIManager : SeyangMonoSingleton<SeyangUIManager>
{
    protected override bool IsDontDestroyOnLoad => false;
    
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject gameFailPanel;
    
    public void ShowGameWinPanel()
    {
        gameWinPanel.SetActive(true);
    }

    public void ShowGameFailPanel()
    {
        gameFailPanel.SetActive(true);
    }
}

