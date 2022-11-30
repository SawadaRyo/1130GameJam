using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("������������")]
    float _fristTime = 120f;
    [SerializeField, Tooltip("�����J�E���g�_�E��")]
    float _countDownTime = 3f;

    [Tooltip("�Q�[������")]
    bool _isGame = false;
    [Tooltip("�Q�[�����̃X�R�A")]
    FloatReactiveProperty _score = null;
    [Tooltip("�Q�[�����̂���")]
    FloatReactiveProperty _money = null;
    [Tooltip("��������")]
    FloatReactiveProperty _time = null;
    [Tooltip("�J�E���g�_�E��")]
    FloatReactiveProperty _countDown = null;

    public bool IsGame => _isGame;
    public IReactiveProperty<float> ScoreValue => _score;
    public IReactiveProperty<float> MoneyValue => _money;
    public IReactiveProperty<float> TimeValue => _time;
    public IReactiveProperty<float> CountDownTimeValue => _countDown;

    public void Init()
    {
        _isGame = true;
        _score = new FloatReactiveProperty(0);
        _money = new FloatReactiveProperty(0);
        _time = new FloatReactiveProperty(_fristTime);
        _countDown = new FloatReactiveProperty(_countDownTime);
        StartCoroutine(TimeCount());
    }

    /// <summary>
    /// �X�R�A�A���\�[�X�ǉ�
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScoreAndMoney(float addValue)
    {
        _score.Value += addValue;
        _money.Value += addValue;
    }

    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScore(float addValue)
    {
        _score.Value += addValue;
    }

    /// <summary>
    /// ���\�[�X�g�p
    /// </summary>
    /// <param name="useValue"></param>
    public void UseMoney(float useValue)
    {
        _money.Value -= useValue;
    }
    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="subtractionValue"></param>
    public void SubtractionScore(float subtractionValue)
    {
        _score.Value -= subtractionValue;
        _score.Value = _score.Value < 0 ? 0 : _score.Value;
    }

    IEnumerator TimeCount()
    {
        while (true)
        {
            _time.Value -= Time.deltaTime;
            if (_time.Value <= 0)
            {

            }
            yield return null;
        }
    }
    IEnumerator CountDown()
    {
        while (true)
        {
            _countDown.Value -= Time.deltaTime;
            if (_time.Value <= 0)
            {

            }
            yield return null;
        }
    }

    void OnDisable()
    {
        _score.Dispose();
        _money.Dispose();
        _time.Dispose();
        _countDown.Dispose();
    }
}
