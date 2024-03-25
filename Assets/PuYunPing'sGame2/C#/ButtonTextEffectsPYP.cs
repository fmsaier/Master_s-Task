using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextEffectsPYP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text buttonText; // 按钮文本组件
    private Color originalColor; // 原始文本颜色
    private Color highlightColor = Color.yellow; // 高亮颜色

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>(); // 获取按钮文本组件
        originalColor = buttonText.color; // 记录原始文本颜色
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = highlightColor; // 鼠标进入时，设置文本高亮颜色
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = originalColor; // 鼠标离开时，恢复文本原始颜色
    }
}
