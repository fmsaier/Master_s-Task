using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject KonwledgeUI;
    public void CloseKnowledge()
    { 
        KonwledgeUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
