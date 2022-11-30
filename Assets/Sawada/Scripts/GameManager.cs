using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("初期制限時間")]
    float _fristTime = 120f;
    [SerializeField, Tooltip("初期カウントダウン")]
    float _countDownTime = 3f;
    [SerializeField, Tooltip("初期制限時間")]
    GameObject _panel = null;

    float _insValue = 1f;

    [Tooltip("ゲーム判定")]
    bool _isGame = false;
    [Tooltip("ゲーム内のスコア")]
    FloatReactiveProperty _score = null;
    [Tooltip("ゲーム内のお金")]
    FloatReactiveProperty _money = null;
    [Tooltip("制限時間")]
    FloatReactiveProperty _time = null;
    [Tooltip("カウントダウン")]
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

    public void GameOver()
    {
        _isGame = false;
        _panel.SetActive(true);
        StopCoroutine(TimeCount());
    }

    /// <summary>
    /// スコア、リソース追加
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScoreAndMoney(float addValue)
    {
        _score.Value += addValue;
        _money.Value += (addValue * _insValue);
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScore(float addValue)
    {
        CRIAudioManager.instance.CRIPlaySE(23);
        _score.Value += (addValue * _insValue);
    }

    /// <summary>
    /// リソース使用
    /// </summary>
    /// <param name="useValue"></param>
    public void UseMoney(float useValue)
    {
        CRIAudioManager.instance.CRIPlaySE(10);
        _money.Value -= useValue;
    }
    /// <summary>
    /// スコア減算
    /// </summary>
    /// <param name="subtractionValue"></param>
    public void SubtractionScore(float subtractionValue)
    {
        CRIAudioManager.instance.CRIPlaySE(17);
        _score.Value -= subtractionValue;
        _score.Value = _score.Value < 0 ? 0 : _score.Value;
    }
    /// <summary>
    /// 集金率UP
    /// </summary>
    /// <param name="upValue"></param>
    public void MoneyValueUp(float upValue)
    {
        CRIAudioManager.instance.CRIPlaySE(22);
        _insValue += upValue;
    }

    IEnumerator TimeCount()
    {
        while (true)
        {
            _time.Value -= Time.deltaTime;
            if (_time.Value < 0)
            {
                GameOver();
                break;
            }
            yield return null;
        }
    }
    public IEnumerator CountDown()
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
