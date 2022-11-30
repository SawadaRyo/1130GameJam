using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


//テキストで表示する値を補間し滑らかに表示する為のクラス
public class InterpolationContoller
{
    [Tooltip("補間仕切るまでの時間")]
    float _interpolationRaito = 0.1f;
    [Tooltip("現在の値")]
    float _currentValue = 0f;
    [Tooltip("対象のText")]
    Text _targetText = null;

    public InterpolationContoller(float interpolationRaito, float currentValue, Text targetText)
    {
        _interpolationRaito = interpolationRaito;
        _currentValue = currentValue;
        _targetText = targetText;
    }

    //値の補間
    public void ChangeValue(float endValue)
    {
        DOTween.To(() => _currentValue,
            x => _currentValue = x
            , endValue
            , _interpolationRaito)
            .OnUpdate(() => _targetText.text = _currentValue.ToString("00000"))
            .OnComplete(() => _targetText.text = endValue.ToString("00000"));
    }
}
