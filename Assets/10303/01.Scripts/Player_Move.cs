using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] GameObject attack_1;
    [SerializeField]
    private float _speed = 0;
    private BoxCollider2D _coll;
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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(x, y) * _speed;
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.F))
        {
            
        }
    }
}
