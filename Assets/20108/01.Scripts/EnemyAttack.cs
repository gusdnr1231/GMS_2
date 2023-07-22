using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject AttackEft;

    private EnemyAttackType enemyType;
    public EnemyMain EnemyStats;

    public LayerMask whatIsShiled;

    private void Awake()
    {
        EnemyStats = GetComponent<EnemyMain>();
    }

    private void FixedUpdate()
    {
        
    }

    public void SetAttackType(EnemyAttackType enemyType)
    {
        this.enemyType = enemyType;
    }

    public void EnemyState()
    {
        if(enemyType == EnemyAttackType.Melee) MeleeAttack();
        if(enemyType == EnemyAttackType.LongDis) LongDisAttack();
        if(enemyType == EnemyAttackType.None) return;
    }

    private void MeleeAttack()
    {
		Collider2D enemy = Physics2D.OverlapCircle(EnemyStats.BasePos.position, EnemyStats.enemyDis, EnemyStats.whatIsEnemy);
        /*Mathf.Lerp(EnemyStats.BasePos.position.x,enemy.transform.position.x,EnemyStats.enemyDis * 0.06f);*/
        
    }

    IEnumerator MeleeAttackAnimation()
    {
        yield return null;
    }

    private void LongDisAttack()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Player")) Debug.Log("플레이어 공격");
		if (collision.gameObject.CompareTag("Pet")) Debug.Log("펫 공격");
		if (collision.gameObject.CompareTag("Shiled")) Debug.Log("방어막 공격");
	}
}
