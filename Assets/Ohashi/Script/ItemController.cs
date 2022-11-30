using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("���G���Ԃ̃C���^�[�o��")]
    float _godInterval = 5f;
    [SerializeField, Tooltip("�W�����A�b�v�̃C���^�[�o��")]
    float _itemUpInterval = 5f;
    [SerializeField, Tooltip("GameManager���i�[")]
    GameManager _gameManager;
    [SerializeField, Tooltip("�A�C�e���w���ɕK�v�Ȃ���1")]
    float _needMoney1 = 10f;
    [SerializeField, Tooltip("�A�C�e���w���ɕK�v�Ȃ���2")]
    float _needMoney2 = 10f;

    public FloatReactiveProperty NeedMoney1 = null;
    public FloatReactiveProperty NeedMoney2 = null;

    bool _isGod = false;
    bool _isItemUp = false;

    public bool IsGod => _isGod;
    private void Start()
    {
        NeedMoney1 = new FloatReactiveProperty(_needMoney1);
        NeedMoney2 = new FloatReactiveProperty(_needMoney2);
    }
    /// <summary>
    /// �������g����莞�Ԗ��G�ɂȂ�
    /// </summary>
    public void OnGodItem()
    {
        if (!_isGod)
        {
            _gameManager.UseMoney(NeedMoney1.Value);
            StartCoroutine(EventInterval());
            Debug.Log("��q");
        }
    }

    /// <summary>
    /// �������g���W�������A�b�v
    /// </summary>
    public void OnItemUp()
    {
        if (!_isItemUp && _gameManager.IsGame)
        {
            _gameManager.UseMoney(NeedMoney2.Value);
            StartCoroutine(EventInterval2());
            //�W�������グ��
            _gameManager.MoneyValueUp(0.1f);
            Debug.Log("�W�����A�b�v");
        }
    }

    /// <summary>
    /// �C�x���g�̃C���^�[�o��
    /// </summary>
    private IEnumerator EventInterval()
    {

        _isGod = true;
        yield return new WaitForSeconds(_godInterval);
        _isGod = false;
    }

    /// <summary>
    /// �C�x���g�̃C���^�[�o��
    /// </summary>
    private IEnumerator EventInterval2()
    {
        _isItemUp = true;
        yield return new WaitForSeconds(_itemUpInterval);
        _isItemUp = false;
    }

    private void OnDisable()
    {
        NeedMoney1.Dispose();
        NeedMoney2.Dispose();
    }
}
