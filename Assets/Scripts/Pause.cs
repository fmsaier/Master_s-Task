using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject BackBtn;
    public AudioSource click;

    public void ShowPauseMenu()
    {
        click.Play();
        BackBtn.SetActive(true);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;//让时间运算比率为0从而达到暂停的效果
    }

    public void BackGame()
    {
        click.Play();
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        BackBtn.SetActive(false);
    }
}
