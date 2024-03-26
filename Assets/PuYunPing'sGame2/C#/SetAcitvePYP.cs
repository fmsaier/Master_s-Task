using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetAcitvePYP : MonoBehaviour
{
    public int ElementNumberlow;
    public int ElementNumberbig;
    public Text textElement;
    public Image imageElement;
    public bool flag;

    private float transitionDuration = 0.3f; // 过渡持续时间为0.3秒

    void Update()
    {
        if (flag)
        {
            if (ElementNumberlow <= WholePYP.PYPElement && WholePYP.PYPElement <= ElementNumberbig)
            {
                if (textElement!=null)
                {
                    StartCoroutine(ChangeAlphaValueOverTime(textElement, 1f)); 
                }
                if (imageElement!=null)
                {
                    StartCoroutine(ChangeAlphaValueOverTime(imageElement, 1f));
                }

            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (ElementNumberlow <= WholePYP.PYPElement && WholePYP.PYPElement <= ElementNumberbig)
            {
                if (textElement != null)
                {
                    StartCoroutine(ChangeAlphaValueOverTime(textElement, 1f));
                }
                if (imageElement != null)
                {
                    StartCoroutine(ChangeAlphaValueOverTime(imageElement, 1f));
                }
            }
            else
            {
                if(WholePYP.PYPElement > ElementNumberbig)
                {
                    gameObject.SetActive (false);
                }
                //SetAlphaValue(textElement, 0f); // 设置 Text 元素完全透明
                //SetAlphaValue(imageElement, 0f); // 设置 Image 元素完全透明
            }
        }
    }

    IEnumerator ChangeAlphaValueOverTime(Graphic element, float targetAlpha)
    {
        Color startColor = element.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
        float startTime = Time.time;
        float endTime = startTime + transitionDuration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / transitionDuration;
            element.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        element.color = endColor; // 确保最终颜色准确无误
    }

    void SetAlphaValue(Graphic element, float alphaValue)
    {
        if (element != null)
        {
            Color currentColor = element.color;
            currentColor.a = alphaValue; // 修改透明度值
            element.color = currentColor; // 更新元素的颜色
        }
    }
}