using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("スポーン位置")]
    private Transform[] _normalPos;
    [SerializeField, Tooltip("スポーンするオブジェクト")]
    private NormalEnemyController[] _normalEnemy;
    [SerializeField, Tooltip("隕石のオブジェクト")]
    private SpecialEnemyController _specialEnemy;
    [SerializeField, Tooltip("隕石のスポーン位置")]
    private Transform _specialPos;
    [SerializeField]
    private GameObject _target;
    [SerializeField, Tooltip("スポーンのインターバル")]
    private float _interval = 3f;
    [SerializeField, Tooltip("アイテムのクラス")]
    ItemController _itemController;

    private bool _isGenerate = false;

    private void Update()
    {
        if(!_isGenerate && !_itemController.IsGod)
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
            var special = Instantiate(_specialEnemy, _specialPos.position, _specialPos.rotation);
            special.InIt(_target);
            CRIAudioManager.instance.CRIPlaySE(37);
        }
        else
        {
            var normal = Instantiate(_normalEnemy[enemyNum], _normalPos[posNum].position, _normalPos[posNum].rotation);
            normal.InIt(_target);
            CRIAudioManager.instance.CRIPlaySE(36);
        }
    }
}
