using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField,Tooltip("GameManager‚ðŠi”[")]
    GameManager _gameMnager = null;
    [Tooltip("InterpolationContoller‚ðŠi”[")]
    InterpolationContoller _interpolateScore = null;

    void Start()
    {
        //_interpolateScore = new InterpolationContoller(0.1f,_gameMnager.Score.Value, GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>());
    }
    
    void ChangeValue()
    {
        _gameMnager.Score
            .Subscribe(score =>
            {
                _interpolateScore.ChangeValue(score);
            }).AddTo(this);
    }
}
