using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("���G���Ԃ̃C���^�[�o��")]
    private float _godInterval = 5f;
    [SerializeField, Tooltip("�W�����A�b�v�̃C���^�[�o��")]
    private float _itemUpInterval = 5f;

    private bool _isGod = false;
    private bool _isItemUp = false;

    public bool IsGod => _isGod;
    /// <summary>
    /// �������g����莞�Ԗ��G�ɂȂ�
    /// </summary>
    public void OnGodItem()
    {
        if(!_isGod)
        {
            StartCoroutine(EventInterval());
            Debug.Log("��q");
            //���������炷
        }
    }

    /// <summary>
    /// �������g���W�������A�b�v
    /// </summary>
    public void OnItemUp()
    {
        if(!_isItemUp)
        {
            StartCoroutine(EventInterval2());
            //�W�������グ��
            //���������炷
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
}