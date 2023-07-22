using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 movepos;
    [SerializeField] float hp = 100;
    void Update()
    {
        movepos = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.position += movepos * Time.deltaTime * 6;
    }
    public void Hit(float decreaseHP)
    {
        hp -= decreaseHP;
    }
}
