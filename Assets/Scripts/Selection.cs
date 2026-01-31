using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class Selection : MonoBehaviour
{
    private Button button;
    private Image image;
    private TMP_Text label;
    public SelectionType selection;
    private Tween fadeTween;
    private void Awake()
    {
        button = GetComponent<Button>();
        image = button.image;
        label = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        Debug.Log("call");
        GamePlay.Instance.Interact(selection);
    }

    public void Hidden(Action callBack = null)
    {
        fadeTween?.Kill();
        button.interactable = false;

        fadeTween = DOTween.Sequence()
            .Append(image.DOFade(0f, 1f))
            .Join(label.DOFade(0f, 1f))
            .SetEase(Ease.OutQuad)
            .SetLink(gameObject).OnComplete(()=> callBack?.Invoke());
    }

    public void Expose()
    {
        fadeTween?.Kill();
        button.interactable = false;

        fadeTween = DOTween.Sequence()
            .Append(image.DOFade(1f, 0.5f))
            .Join(label.DOFade(1f, 0.5f))
            .SetEase(Ease.OutQuad)
            .OnComplete(() => button.interactable = true)
            .SetLink(gameObject);
    }
}


