using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Weapon : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(Enemy.gameObject);
        }
    }
}
