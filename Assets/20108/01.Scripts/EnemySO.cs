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
    [Header("�� ü��")]
    public float enemyHP = 0; //�� ü��
    [Header("�� �̵�")]
    public float enemySpeed = 0; //�� �̵� �ӵ�
    [Header("�� ����")]
    public float enemyAttack = 0; //�� ���ݷ�
    public float enemyDelay = 0; //�� ���� ������
    [Header("�� �����Ÿ�")]
    public float enemyDis = 0; //�� �����Ÿ�
}
