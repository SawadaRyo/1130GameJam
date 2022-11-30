using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonationBox : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField]GameObject _resultPanel;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>(); 
        _resultPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<NormalEnemyController>(out var enemy))
        {
            _gameManager.SubtractionScore(enemy.EnemyScore);
        }
        else if(other.TryGetComponent<SpecialEnemyController>(out var specialEnemy))
        {
            _gameManager.GameOver();
            _resultPanel.SetActive(true);
        }
    }
}
