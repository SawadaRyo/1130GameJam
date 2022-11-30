using UnityEngine;

public class NormalEnemyController : EnemyBase
{
    [SerializeField]
    private float _enemyScore = 10f;
    protected override void EnemHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void EnemyClick()
    {
        Destroy(_clickEnemy);
    }
}
