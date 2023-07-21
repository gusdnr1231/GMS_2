using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMain : PoolableMono
{
    private Transform basePos;
    public Transform BasePos => basePos;
    [SerializeField] static private EnemySO EnemyType;
	public LayerMask whatIsEnemy;

	#region Àû ½ºÅÈ
	public float enemyMaxHP = EnemyType.enemyHP;
    public float enemyCurHP = 0;
    public float enemySpeed = EnemyType.enemySpeed;
    public float enemyAttack = EnemyType.enemyAttack;
    public float enemyDelay = EnemyType.enemyDelay;
    public float enemyDis = EnemyType.enemyDis;
    public EnemyAttackType enemyAttackType = EnemyType.enemyType;
    public ElementType enemyElement = EnemyType.enemyElement;
	#endregion

    private bool isAttack = false;
    public bool IsAttack => isAttack;

    public EnemyAttack EnemyAttack;
    public EnemyMove EnemyMove;

    private void FixedUpdate()
    {
        if(enemyCurHP <= 0) GotoPool();

    }

    public override void Init()
    {
		enemyCurHP = enemyMaxHP;
		basePos = transform.Find("BasePosition").GetComponent<Transform>();
        EnemyAttack = GetComponent<EnemyAttack>();
        EnemyAttack.SetAttackType(enemyAttackType);
        EnemyMove = GetComponent<EnemyMove>();
	}

    public void GotoPool()
	{
		PoolManager.Instance.Push(this);
	}
}
