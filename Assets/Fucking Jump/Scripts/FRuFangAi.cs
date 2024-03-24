using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRuFangAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.Title.text = "肛门癌";
        FGameManager.Instance.StartCoroutine(
            FGameManager.Instance.ChangeInfo(FResourceManager.Instance.Info
            , "现在来击败肛门癌吧，它是泸州市发病率第二高的癌症哦！", 1));
        FResourceManager.Instance.GangMenAiGe.SetActive(true);
        Destroy(gameObject);
    }
}
