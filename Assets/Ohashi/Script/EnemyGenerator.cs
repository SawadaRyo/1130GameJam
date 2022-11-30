using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("スポーン位置")]
    private Transform[] _normalPos;
    [SerializeField, Tooltip("スポーンするオブジェクト")]
    private GameObject[] _normalEnemy;
    [SerializeField, Tooltip("隕石のオブジェクト")]
    private GameObject _specialEnemy;
    [SerializeField, Tooltip("隕石のスポーン位置")]
    private Transform _specialPos;
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
        int enemyNum = Random.Range(0, _normalEnemy.Length + 1);
        int posNum = Random.Range(0, _normalPos.Length);
        if (enemyNum == _normalEnemy.Length)
        {
            Instantiate(_specialEnemy, _specialPos.position, _specialPos.rotation);
        }
        else
        {
            Instantiate(_normalEnemy[enemyNum], _normalPos[posNum].position, _normalPos[posNum].rotation);
        }
    }
}
