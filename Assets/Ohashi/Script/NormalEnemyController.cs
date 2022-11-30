using UnityEngine;

public class NormalEnemyController : EnemyBase
{
    protected override void EnemHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void EnemyClick()
    {
        Destroy(_clickEnemy);
    }
}
