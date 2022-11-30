using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField,Tooltip("GameManager���i�[")]
    GameManager _gameMnager = null;
    [SerializeField, Tooltip("Timer�p��Text")]
    Text  _timeText = null;
    [SerializeField, Tooltip("Money�p��Text")]
    Text  _moneyText = null;
    [SerializeField, Tooltip("Score�p��Text")]
    Text  _scoreText = null;

    [Tooltip("Score�p��InterpolationContoller���i�[")]
    InterpolationContoller _interpolateScore = null;
    [Tooltip("Money�p��InterpolationContoller���i�[")]
    InterpolationContoller _interpolateMoney = null;

    void Start()
    {
        _gameMnager.Init();
        _interpolateScore = new InterpolationContoller(0.1f,_gameMnager.ScoreValue.Value, _scoreText);
        _interpolateMoney = new InterpolationContoller(0.1f, _gameMnager.MoneyValue.Value, _moneyText);
        ChangeValue();
    }
    
    void ChangeValue()
    {
        _gameMnager.ScoreValue
            .Subscribe(score =>
            {
                _interpolateScore.ChangeValue(score);
            }).AddTo(this);
        _gameMnager.MoneyValue
            .Subscribe(money =>
            {
                _interpolateMoney.ChangeValue(money);
            }).AddTo(this);
        _gameMnager.TimeValue
            .Subscribe(time =>
            {
                _timeText.text = time.ToString("000");
            }).AddTo(this);
        _gameMnager.TimeValue
            .Subscribe(time =>
            {
                _timeText.text = time.ToString("000");
            }).AddTo(this);
    }
}
