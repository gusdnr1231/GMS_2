using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    [SerializeField] GameObject attack_1;
    [SerializeField] private float _speed = 0;
    [SerializeField] private Vector2 inputVec;
    private BoxCollider2D _coll;
    private Rigidbody2D _rb;
    private Animator Ani;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        P_Move();
    }

    void P_Move()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.A))
        {
            // (이거 하다 말았다)애니메이션 실행 Ani.
        }
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + nextVec);
        
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.F))
        {
            
        }
    }
}
