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
        Time.timeScale = 0f;//��ʱ���������Ϊ0�Ӷ��ﵽ��ͣ��Ч��
    }

    public void BackGame()
    {
        click.Play();
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        BackBtn.SetActive(false);
    }
}
