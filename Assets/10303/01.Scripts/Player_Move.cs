using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    [SerializeField] GameObject attack_1;
    [SerializeField] private float _speed = 0;
    [SerializeField] private Vector2 inputVec;
    [SerializeField] private GameObject AttackPoint;
    private BoxCollider2D _coll;
    private Rigidbody2D _rb;
    private Animator Ani;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        P_Move();
        Skin();
        Attack();
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

    private void Skin()
    {
        if (Input.GetButton("Horizontal"))
        {
            Ani.SetBool("UPidle", false);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            Ani.SetBool("Side", true);
            Ani.SetBool("Isrun", true);
        }
        else Ani.SetBool("Isrun", false);



        if (Input.GetButton("Vertical"))
        {
            Ani.SetBool("Side", false);


            if (Input.GetAxisRaw("Vertical") == -1)
            {
                Ani.SetBool("UPidle", false);
                Ani.SetBool("Downrun", true);
            }



            if (Input.GetAxisRaw("Vertical") == 1)
            {
                Ani.SetBool("UPidle", true);
                Ani.SetBool("UPrun", true);
            }


        }
        else
        {
            Ani.SetBool("Downrun", false); Ani.SetBool("UPrun", false);
        }

        }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.F))
        {
            AttackPoint.transform.position = inputVec;
        }
    }
}
