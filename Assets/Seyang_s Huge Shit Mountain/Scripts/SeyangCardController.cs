using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SeyangCardController : MonoBehaviour
{
    [SerializeField] private Button clickButton;
    [SerializeField] private Image contentImage;
    [SerializeField] private Image whatImage;
    [SerializeField] private float fadeInOutDuration;

    public int CardTypeIndex { get; private set; }
    public bool IsShow { get; private set; } = false;
    public event Action<SeyangCardController> onClick;
    public event Action onClear; 
    // public event Action onAnimFinished; 

    private void Start()
    {
        clickButton.onClick.AddListener(OnClickCard);
    }

    public void SetConfig(int cardTypeIndex,Sprite sprite)
    {
        this.CardTypeIndex = cardTypeIndex;
        this.contentImage.sprite = sprite;
    }

    private void OnClickCard()
    {
        if (IsShow == false)
        {
            ShowContent();
        }
    }

    public void ShowContent()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, fadeInOutDuration))
            .AppendCallback(() =>
            {
                contentImage.gameObject.SetActive(true);
                whatImage.gameObject.SetActive(false);
            })
            .Append(transform.DOScale(Vector3.one, fadeInOutDuration))
            .onComplete += () => onClick?.Invoke(this);
    }

    public void HideContent()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, fadeInOutDuration))
            .AppendCallback(() =>
            {
                contentImage.gameObject.SetActive(false);
                whatImage.gameObject.SetActive(true);
            })
            .Append(transform.DOScale(Vector3.one, fadeInOutDuration));
    }

    public void Clear()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, fadeInOutDuration))
            .onComplete += () =>
        {
            onClear?.Invoke();
            gameObject.SetActive(false);
        };
    }
}
