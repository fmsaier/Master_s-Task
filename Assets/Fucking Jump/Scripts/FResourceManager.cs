using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FResourceManager : MonoBehaviour
{
    public static FResourceManager Instance;
    [Header("��Ϸ�ڵ���")]
    public GameObject Block;
    public GameObject Medicine;
    public GameObject Pill;
    public GameObject Wine;
    public GameObject Cigarette;
    public GameObject Apple;
    public GameObject Vegetable;

    [Header("��ɫ���")]
    public GameObject Character;
    public GameObject GanAiGe;
    public GameObject RuFangAiGe;
    public GameObject GangMenAiGe;
    public GameObject FeiAiGe;

    [Header("UI���")]
    public TextMeshProUGUI PillCount;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI InfoPlus;
    public TextMeshProUGUI Title;
    public GameObject HeartsParent;
    public Image UpCDMask;
    public Image DownCDMask;
    public Image ShootCDMask;
    public GameObject PauseTips;
    public Sprite PauseIcon;
    public Sprite ContinueIcon;
    public Button PauseButton;
    public GameObject FinalPanel;
    public TextMeshProUGUI FinalText;
    public GameObject SettingPanel;
    public TextMeshProUGUI SettingText;
    public Button UpButton;
    public Button DownButton;
    public Button ShootButton;

    private void Awake()
    {
        Instance = this;
    }
}
