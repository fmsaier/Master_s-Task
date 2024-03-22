using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFeiAi : FAi
{
    public override void Die()
    {
        FResourceManager.Instance.FinalPanel.SetActive(true);
        FResourceManager.Instance.FinalText.text =
            "恭喜你战胜了所有的癌症，相信你一定也学到了一些预防癌症的知识，在以后的生活中一定要保持健康哦！";
        Time.timeScale = 0;
    }
}
