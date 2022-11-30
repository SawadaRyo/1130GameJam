using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField, Tooltip("Score�p��Text")]
    Text _scoreText = null;
    [SerializeField, Tooltip("GameManager���i�[����ϐ�")]
    GameManager _GameManager = null;

    void OnEnable()
    {
        _scoreText.text = _GameManager.ScoreValue.Value.ToString("000000");
    }
}
