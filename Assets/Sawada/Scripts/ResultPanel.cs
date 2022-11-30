using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField, Tooltip("Score—p‚ÌText")]
    Text _scoreText = null;
    [SerializeField, Tooltip("GameManager‚ğŠi”[‚·‚é•Ï”")]
    GameManager _GameManager = null;

    void OnEnable()
    {
        _scoreText.text = _GameManager.ScoreValue.Value.ToString("000000");
    }
}
