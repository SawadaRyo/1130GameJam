using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�X�|�[���ʒu")]
    private Transform[] _normalPos;
    [SerializeField, Tooltip("�X�|�[������I�u�W�F�N�g")]
    private GameObject[] _normalEnemy;
    [SerializeField, Tooltip("覐΂̃I�u�W�F�N�g")]
    private GameObject _specialEnemy;
    [SerializeField, Tooltip("覐΂̃X�|�[���ʒu")]
    private Transform _specialPos;
    [SerializeField, Tooltip("�X�|�[���̃C���^�[�o��")]
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
    /// �X�|�[���̃C���^�[�o��
    /// </summary>
    private IEnumerator GenerateInterval()
    {
        _isGenerate = true;
        yield return new WaitForSeconds(_interval);
        Generate();
        _isGenerate = false;
    }

    /// <summary>
    /// �G�l�~�[�̃X�|�[��
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
