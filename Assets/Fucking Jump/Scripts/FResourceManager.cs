using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FResourceManager : MonoBehaviour
{
    public static FResourceManager Instance;

    public GameObject Block;
    public GameObject Medicine;
    public GameObject Pill;
    public GameObject Wine;
    public GameObject Cigarette;
    public GameObject Apple;
    public GameObject Vegetable;

    public GameObject Character;

    public TextMeshProUGUI PillCount;
    public GameObject HeartsParent;
    public Image UpCDMask;
    public Image DownCDMask;
    public Image ShootCDMask;
    public GameObject PauseTips;
    public Image Pause;

    private void Awake()
    {
        Instance = this;
    }
}
