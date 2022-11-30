using UnityEngine;

public class SpecialEnemyController : EnemyBase
{
    [SerializeField]
    private int _destroyClickCount = 5;
    [SerializeField]
    private float _enemySpeed = 2f;

    protected override void EnemyClick()
    {
        _clickCount++;
        if(_clickCount >= _destroyClickCount)
        {
            Destroy(_clickEnemy);
        }
    }

    protected override void EnemyMove()
    {
        _rb2D.AddForce(Vector2.down * _enemySpeed, ForceMode2D.Impulse);
    }
}
