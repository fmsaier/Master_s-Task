using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGanAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.Title.text = "�鷿��";
        FGameManager.Instance.StartCoroutine(
            FGameManager.Instance.ChangeInfo(FResourceManager.Instance.Info
            , "�����������鷿���ɣ����������з����ʵ����ߵİ�֢Ŷ��", 1));
        FResourceManager.Instance.RuFangAiGe.SetActive(true);
        Destroy(gameObject);
    }
}
