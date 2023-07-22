using Unity.Mathematics;
using UnityEngine;

public class NagaBody : Enemy
{
    [SerializeField] GameObject dieParticle;
    [SerializeField] float hp = 30;

    public override void hit(float decreaseHP)
    {
        hp -= decreaseHP;
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Instantiate(dieParticle, gameObject.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().Hit(10);
        }
    }
}
