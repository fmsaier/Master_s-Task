using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tin_R : MonoBehaviour
{
    [SerializeField] private GameObject Scenewin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scenewin.SetActive(true);
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
