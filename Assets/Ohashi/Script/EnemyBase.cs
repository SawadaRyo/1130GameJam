using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, IPointerClickHandler
{
    protected int _clickCount = 0;
    protected GameObject _clickEnemy;
    protected Rigidbody2D _rb2D;

    /// <summary>
    /// �G�l�~�[���N���b�N�����Ƃ��̏���
    /// </summary>
    protected abstract void EnemyClick();

    /// <summary>
    /// �G�l�~�[�̈ړ�
    /// </summary>
    protected abstract void EnemyMove();

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        EnemyMove();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickEnemy = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log("aa");
        EnemyClick();
    }
}
