using UnityEngine;

public class SpecialEnemyController : EnemyBase
{
    [SerializeField, Tooltip("�j��ɕK�v�ȃN���b�N��")]
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
