using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRuFangAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.Title.text = "���Ű�";
        FGameManager.Instance.StartCoroutine(
            FGameManager.Instance.ChangeInfo(FResourceManager.Instance.Info
            , "���������ܸ��Ű��ɣ����������з����ʵڶ��ߵİ�֢Ŷ��", 1));
        FResourceManager.Instance.GangMenAiGe.SetActive(true);
        Destroy(gameObject);
    }
}
