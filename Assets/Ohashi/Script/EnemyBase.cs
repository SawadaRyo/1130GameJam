using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Tooltip("移動スピード")]
    protected float _moveSpeed = 3f;

    protected GameObject _target;
    protected int _clickCount = 0;
    protected GameObject _clickEnemy;
    protected Rigidbody2D _rb2D;
    private SpriteRenderer _sr;

    /// <summary>
    /// エネミーをクリックしたときの処理
    /// </summary>
    protected abstract void EnemyClick();

    /// <summary>
    /// ターゲットに接触したときの処理
    /// </summary>
    protected abstract void EnemHit();

    public void InIt(GameObject target)
    {
        _target = target;
    }

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        EnemyMove();
    }

    /// <summary>
    /// エネミーの移動処理
    /// </summary>
    private void EnemyMove()
    {
        if (transform.position.x < 0)
        {
            _sr.flipX = true;
        }
        var distance = (_target.transform.position - transform.position).normalized;
        _rb2D.AddForce(distance * _moveSpeed, ForceMode2D.Impulse);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickEnemy = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log("ヒット");
        EnemyClick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _target)
        {
            EnemHit();
        }
    }
}
