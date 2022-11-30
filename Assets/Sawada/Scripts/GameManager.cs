using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    [Tooltip("ゲーム内のスコア")]
    FloatReactiveProperty _score = null;
    [Tooltip("ゲーム内のお金")]
    FloatReactiveProperty _money = null;
    [Tooltip("制限時間")]
    FloatReactiveProperty _time = null;

    public IReactiveProperty<float> Score =>  _score;
    public IReactiveProperty<float> Money => _money;
    public IReactiveProperty<float> Time => _time;
    
    public void Init()
    {
        _score = new FloatReactiveProperty(0);
        _money = new FloatReactiveProperty(0);
        _time = new FloatReactiveProperty(300);
    }


    public void AddScoreAndMoney(float addValue)
    {
        _score.Value += addValue;
        _money.Value += addValue;
    }

    public void AddScore(float addValue)
    {
        _score.Value += addValue;
    }

    public void UseMoney(float useValue)
    {
        _money.Value -= useValue;
    }

    public void SubtractionScore(float subtractionValue)
    {
        _score.Value -= subtractionValue;
        _score.Value = _score.Value < 0 ? 0 : _score.Value;
    }

    private void OnDisable()
    {
        _score.Dispose();
        _money.Dispose();
        _time.Dispose();
    }
}
