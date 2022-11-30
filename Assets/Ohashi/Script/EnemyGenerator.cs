using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�X�|�[���ʒu")]
    private Transform[] _normalPos;
    [SerializeField, Tooltip("�X�|�[������I�u�W�F�N�g")]
    private NormalEnemyController[] _normalEnemy;
    [SerializeField, Tooltip("覐΂̃I�u�W�F�N�g")]
    private SpecialEnemyController _specialEnemy;
    [SerializeField, Tooltip("覐΂̃X�|�[���ʒu")]
    private Transform _specialPos;
    [SerializeField]
    private GameObject _target;
    [SerializeField, Tooltip("�X�|�[���̃C���^�[�o��")]
    private float _interval = 3f;
    [SerializeField, Tooltip("�A�C�e���̃N���X")]
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
