using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipVideoButton : MonoBehaviour
{
    [SerializeField] private Button skipVideoButton;
    [SerializeField] private GameObject target;
    [SerializeField] private VideoPlayer videoPlayer;
    
    private void Start()
    {
        skipVideoButton.onClick.AddListener(StartGame);
        videoPlayer.loopPointReached += _ => StartGame();
    }

    private void StartGame()
    {
        target.SetActive(false);
        SeyangGameManager.Instance.OnGameStart();
    }
}

