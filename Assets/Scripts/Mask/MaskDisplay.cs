using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MaskDisplay : MonoBehaviour
{
    public Image image;

    public int shakeVibrato;
    public float shakeStrength;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void Shake(Action callBack = null)
    {
        transform.DOShakePosition(1f , shakeStrength , shakeVibrato).OnComplete(() =>
        {
            if(callBack != null)
                callBack();
        });

    }
}
