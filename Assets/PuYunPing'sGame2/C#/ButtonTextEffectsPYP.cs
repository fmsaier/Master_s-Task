using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextEffectsPYP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text buttonText; // ��ť�ı����
    private Color originalColor; // ԭʼ�ı���ɫ
    private Color highlightColor = Color.yellow; // ������ɫ

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>(); // ��ȡ��ť�ı����
        originalColor = buttonText.color; // ��¼ԭʼ�ı���ɫ
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = highlightColor; // ������ʱ�������ı�������ɫ
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = originalColor; // ����뿪ʱ���ָ��ı�ԭʼ��ɫ
    }
}
