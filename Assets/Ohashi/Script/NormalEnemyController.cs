using UnityEngine;

public class NormalEnemyController : EnemyBase
{
    [SerializeField]
    private float _enemyScore = 10f;

    public float EnemyScore => _enemyScore;
    protected override void EnemHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void EnemyClick()
    {
        Destroy(_clickEnemy);
    }
}
