using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("スポーン位置")]
    private Transform[] _normalPos;
    [SerializeField, Tooltip("隕石のスポーン位置")]
    private Transform _specialPos;
    [SerializeField, Tooltip("スポーンするオブジェクト")]
    private GameObject[] _enemy;
    [SerializeField, Tooltip("隕石のスポーン位置")]
    private GameObject _specialEnemy;
    [SerializeField, Tooltip("スポーンのインターバル")]
    private float _interval = 3f;

    private bool _isGenerate = false;

    private void Update()
    {
        if(!_isGenerate)
        {
            StartCoroutine(GenerateInterval());
        }
    }

    /// <summary>
    /// スポーンのインターバル
    /// </summary>
    private IEnumerator GenerateInterval()
    {
        _isGenerate = true;
        yield return new WaitForSeconds(_interval);
        Generate();
        _isGenerate = false;
    }

    /// <summary>
    /// エネミーのスポーン
    /// </summary>
    private void Generate()
    {
        int enemyNum = Random.Range(0, _enemy.Length);
        int posNum = Random.Range(0, _normalPos.Length);

        Instantiate(_enemy[enemyNum], _normalPos[posNum].position, _normalPos[posNum].rotation);
    }
}
