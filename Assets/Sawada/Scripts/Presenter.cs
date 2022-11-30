using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField,Tooltip("GameManager‚ðŠi”[")]
    GameManager _gameMnager = null;
    [Tooltip("Score—p‚ÌInterpolationContoller‚ðŠi”[")]
    InterpolationContoller _interpolateScore = null;
    [Tooltip("Money—p‚ÌInterpolationContoller‚ðŠi”[")]
    InterpolationContoller _interpolateMoney = null;

    void Start()
    {
        _gameMnager.Init();
        _interpolateScore = new InterpolationContoller(0.1f,_gameMnager.Score.Value, GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>());
        //_interpolateMoney = new InterpolationContoller(0.1f, _gameMnager.Money.Value, GameObject.FindGameObjectWithTag("MoneyText").GetComponent<Text>());
        ChangeValue();
    }
    
    void ChangeValue()
    {
        _gameMnager.Score
            .Subscribe(score =>
            {
                _interpolateScore.ChangeValue(score);
            }).AddTo(this);
        //_gameMnager.Money
        //    .Subscribe(money =>
        //    {
        //        _interpolateMoney.ChangeValue(money);
        //    }).AddTo(this);
    }
}
