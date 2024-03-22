using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGanAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.Title.text = "乳房癌";
        FGameManager.Instance.StartCoroutine(
            FGameManager.Instance.ChangeInfo(FResourceManager.Instance.Info
            , "现在来击败乳房癌吧，它是泸州市发病率第三高的癌症哦！", 1));
        FResourceManager.Instance.RuFangAiGe.SetActive(true);
        Destroy(gameObject);
    }
}
