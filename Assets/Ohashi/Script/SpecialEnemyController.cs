using UnityEngine;

public class SpecialEnemyController : EnemyBase
{
    [SerializeField, Tooltip("破壊に必要なクリック回数")]
    private int _destroyClickCount = 5;

    protected override void EnemHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void EnemyClick()
    {
        _clickCount++;
        if(_clickCount >= _destroyClickCount)
        {
            Destroy(_clickEnemy);
        }
    }
}
