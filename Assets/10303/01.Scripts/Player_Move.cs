using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PMove();
    }

    void PMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(x, y) * _speed;
    }
}
