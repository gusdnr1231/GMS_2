using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType
{
    None,
    Melee,
    LongDis
};

[CreateAssetMenu(menuName = "SO/EnemyData")]
public class EnemySO : ScriptableObject
{
    public EnemyAttackType enemyType = EnemyAttackType.None;
    [Header("적 체력")]
    public float enemyHP = 0; //적 체력
    [Header("적 이동")]
    public float enemySpeed = 0; //적 이동 속도
    [Header("적 공격")]
    public float enemyAttack = 0; //적 공격력
    public float enemyDelay = 0; //적 공격 딜레이
    [Header("적 감지거리")]
    public float enemyDis = 0; //적 감지거리
}
