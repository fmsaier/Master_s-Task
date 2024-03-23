using System.Collections;
using System.Collections.Generic;
using Dawnize;
using UnityEngine;
using UnityEngine.UI;

public class MedAccoundUI : MonoBehaviour
{
public Text text;
    void Update()
    {
        text.text="当前药剂数量："+dataRecound.medicineAcount;
    }
}
