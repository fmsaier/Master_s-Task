using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_HealthBar : MonoBehaviour
{
    public Text healthNum;
    public static float healthPresent;
    public static float healthMax;

    public Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        healthBar.fillAmount = healthPresent / healthMax;
        healthNum.text = healthPresent.ToString() + "/" + healthMax.ToString();
    }
}
