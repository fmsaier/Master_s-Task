using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeyangGameFailPanel : MonoBehaviour
{
    [SerializeField] private Button backToMainMenuButton;
    [SerializeField] private Button restartButton;
    private void Start()
    {
        backToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SeyangContants.ChengduSceneName));
    }
}

