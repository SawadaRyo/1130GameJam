using UnityEngine;

public class NormalEnemyController : EnemyBase
{
    [SerializeField]
    private float _moveSpeed = 3f;

    protected override void EnemyClick()
    {
        Destroy(_clickEnemy);
    }

    protected override void EnemyMove()
    {
        if(transform.position.x < 0)
        {
            _rb2D.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Impulse);
        }
        else
        {
            _rb2D.AddForce(-Vector2.right * _moveSpeed, ForceMode2D.Impulse);
        }
    }
}
