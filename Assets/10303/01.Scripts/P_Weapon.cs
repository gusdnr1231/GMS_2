using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Weapon : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(Enemy.gameObject);
        }
    }
}