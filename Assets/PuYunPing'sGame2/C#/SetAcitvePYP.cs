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

    private float transitionDuration = 0.3f; // ���ɳ���ʱ��Ϊ0.3��

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
                //SetAlphaValue(textElement, 0f); // ���� Text Ԫ����ȫ͸��
                //SetAlphaValue(imageElement, 0f); // ���� Image Ԫ����ȫ͸��
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

        element.color = endColor; // ȷ��������ɫ׼ȷ����
    }

    void SetAlphaValue(Graphic element, float alphaValue)
    {
        if (element != null)
        {
            Color currentColor = element.color;
            currentColor.a = alphaValue; // �޸�͸����ֵ
            element.color = currentColor; // ����Ԫ�ص���ɫ
        }
    }
}