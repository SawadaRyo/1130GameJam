using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField, Tooltip("Score用のText")]
    Text _scoreText = null;
    [SerializeField, Tooltip("GameManagerを格納する変数")]
    GameManager _GameManager = null;

    void OnEnable()
    {
        _scoreText.text = _GameManager.ScoreValue.Value.ToString("000000");
    }
}
