using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMain : PoolableMono
{
    private Transform BasePos;
    [SerializeField] static private EnemySO EnemyType;

	#region Àû ½ºÅÈ
    private float enemyMaxHP = EnemyType.enemyHP;
    private float enemyCurHP = 0;
    private float enemySpeed = EnemyType.enemySpeed;
    private float enemyAttack = EnemyType.enemyAttack;
    private float enemyDelay = EnemyType.enemyDelay;
    private float enemyDis = EnemyType.enemyDis;
    private EnemyAttackType enemyType = EnemyType.enemyType;
	#endregion

	private void Awake()
    {
        
    }

    public override void Init()
    {
		enemyCurHP = enemyMaxHP;
		BasePos = transform.Find("BasePosition").GetComponent<Transform>();
	}

	public void GotoPool()
	{
		PoolManager.Instance.Push(this);
	}
}
