using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyAttackType enemyType;

    public void SetAttackType(EnemyAttackType enemyType)
    {
        this.enemyType = enemyType;
    }

    public void EnemyAttacking()
    {

    }
}
