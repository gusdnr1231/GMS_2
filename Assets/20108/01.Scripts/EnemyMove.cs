using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public EnemyMain EnemyStats;
	private Rigidbody2D enemyRigid;
	private Vector3 moveDir;
	private Vector3 enemyPos;

	private void Awake()
	{
		EnemyStats = GetComponent<EnemyMain>();
		enemyRigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		enemyRigid.velocity = moveDir * EnemyStats.enemySpeed * Time.fixedDeltaTime;
		Collider2D[] enemies = Physics2D.OverlapCircleAll(EnemyStats.BasePos.position, EnemyStats.enemyDis, EnemyStats.whatIsEnemy);
		if(enemies != null)	EnemyStats.EnemyMove.SetDirectionZero();
	}

	public void SetDirection()
	{
		enemyPos = GameManager.Instance.PlayerTrm.position;
		moveDir = (EnemyStats.BasePos.position - enemyPos).normalized;
	}

	public void SetDirectionZero()
	{
		moveDir = Vector3.zero;
	}
}
