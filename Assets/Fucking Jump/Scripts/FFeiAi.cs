using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFeiAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.FinalPanel.SetActive(true);
        FResourceManager.Instance.FinalText.text =
            "��ϲ��սʤ�����еİ�֢��������һ��Ҳѧ����һЩԤ����֢��֪ʶ�����Ժ��������һ��Ҫ���ֽ���Ŷ��";
        Time.timeScale = 0;
    }
}
