using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


//�e�L�X�g�ŕ\������l���Ԃ����炩�ɕ\������ׂ̃N���X
public class InterpolationContoller
{
    [Tooltip("��Ԏd�؂�܂ł̎���")]
    float _interpolationRaito = 0.1f;
    [Tooltip("���݂̒l")]
    float _currentValue = 0f;
    [Tooltip("�Ώۂ�Text")]
    Text _targetText = null;

    public InterpolationContoller(float interpolationRaito, float currentValue, Text targetText)
    {
        _interpolationRaito = interpolationRaito;
        _currentValue = currentValue;
        _targetText = targetText;
    }

    //�l�̕��
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
