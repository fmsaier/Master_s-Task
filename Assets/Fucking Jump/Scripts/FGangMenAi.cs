using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGangMenAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.FeiAiGe.SetActive(true);
        Destroy(gameObject);
    }
}
