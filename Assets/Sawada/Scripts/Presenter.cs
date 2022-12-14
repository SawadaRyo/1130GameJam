using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField,Tooltip("GameManagerを格納")]
    GameManager _gameMnager = null;
    [SerializeField, Tooltip("GameManagerを格納")]
    ItemController _itemController = null;
    [SerializeField, Tooltip("Timer用のText")]
    Text  _timeText = null;
    [SerializeField, Tooltip("Money用のText")]
    Text  _moneyText = null;
    [SerializeField, Tooltip("Score用のText")]
    Text  _scoreText = null;
    [SerializeField, Tooltip("アイテム購入に必要なお金を表示するText1")]
    Text _needMoneyText1 = null;
    [SerializeField, Tooltip("アイテム購入に必要なお金を表示するText2")]
    Text _needMoneyText2 = null;

    [Tooltip("Score用のInterpolationContollerを格納")]
    InterpolationContoller _interpolateScore = null;
    [Tooltip("Money用のInterpolationContollerを格納")]
    InterpolationContoller _interpolateMoney = null;
    [Tooltip("アイテム購入用のInterpolationContollerを格納1")]
    InterpolationContoller _interpolateNeedMoney1 = null;
    [Tooltip("アイテム購入用のInterpolationContollerを格納2")]
    InterpolationContoller _interpolateNeedMoney2 = null;

    void Start()
    {
        _gameMnager.Init();
        _interpolateScore = new InterpolationContoller(0.1f,_gameMnager.ScoreValue.Value, _scoreText);
        _interpolateMoney = new InterpolationContoller(0.1f, _gameMnager.MoneyValue.Value, _moneyText);
        _interpolateNeedMoney1 = new InterpolationContoller(0.1f, _itemController.NeedMoney1.Value, _needMoneyText1);
        _interpolateNeedMoney2 = new InterpolationContoller(0.1f, _itemController.NeedMoney2.Value, _needMoneyText2);
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

        _itemController.NeedMoney1
            .Subscribe(money =>
            {
                _interpolateNeedMoney1.ChangeValue(money);
            }).AddTo(this);
        _itemController.NeedMoney2
            .Subscribe(money =>
            {
                _interpolateNeedMoney2.ChangeValue(money);
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
