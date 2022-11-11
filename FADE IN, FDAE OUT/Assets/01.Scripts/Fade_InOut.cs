using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

enum FadeSetting { FadeIn, FadeOut }

public class Fade_InOut : MonoBehaviour
{
    [SerializeField] private FadeSetting _fadeSetting;
    [SerializeField] private float _fadeTime;
    [SerializeField] private UnityEvent _fadeEnd;

    private Image _thisImage;
    private float _fadeScale;


    private void Awake() 
    {
        _thisImage = GetComponent<Image>();
    }

    public void Fade()
    {
        switch (_fadeSetting)
        {
            case FadeSetting.FadeIn:
                _fadeScale = 0;
                break;
            case FadeSetting.FadeOut:
                _fadeScale = 1;
                break;
        }
        Sequence seq = DOTween.Sequence();
        seq.Append(_thisImage.DOFade(_fadeScale, _fadeTime));
        seq.AppendCallback(() =>
        {
            _fadeEnd?.Invoke();
        });
    }    
}
