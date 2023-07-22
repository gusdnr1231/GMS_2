using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    
    [SerializeField] private float _speed = 0;
    [SerializeField] private Vector2 inputVec;
    [SerializeField] private GameObject UpAttack;
    [SerializeField] private GameObject SideAttack;
    [SerializeField] private GameObject twoSideAttack;
    [SerializeField] private GameObject DownAttack;

    P_Hp P_HpCode;
   
    private BoxCollider2D _coll;
    private Rigidbody2D _rb;
    private Animator Ani;
    SpriteRenderer spriteRenderer;

    int DieCount = 5;
    void Start()
    {
        P_HpCode = FindObjectOfType<P_Hp>();
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();

        
    }

    void Update()
    {
 

        P_Move();
        Skin();
        Attack();
        P_Die();


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
        //UpAttack.SetActive(false);
       // SideAttack.SetActive(false);
        //DownAttack.SetActive(false);
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Ani.GetBool("Side") == true)
            {
                Ani.SetTrigger("SIDEattack");
            
            }
            else if (Ani.GetBool("UPidle") == true)
            {
                Ani.SetTrigger("UPattack");
                
            }
            else
            {
                Ani.SetTrigger("DWattack");
                
            }

            StartCoroutine(Attacktool());


        }
    }


    IEnumerator Attacktool()
    {
        if(Ani.GetBool("Side") == true)
        {
            if (spriteRenderer.flipX)
            {
                yield return new WaitForSeconds(0.3f);
                twoSideAttack.SetActive(true);
               yield return new WaitForSeconds(0.2f);
                twoSideAttack.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(0.3f);
                SideAttack.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                SideAttack.SetActive(false);
            }
        }

        else if(Ani.GetBool("UPidle") == true)
        {
            yield return new WaitForSeconds(0.3f);
            UpAttack.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            UpAttack.SetActive(false);
        }

        else
        {
            yield return new WaitForSeconds(0.3f);
            DownAttack.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            DownAttack.SetActive(false);
        }

    }


    public IEnumerator Sick()
    {
        int count = 0;

        while (count < 2)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.25f);
            count++;
        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           FindObjectOfType<P_Hp>().Damege();
            DieCount -= 1;
           StartCoroutine(Sick());
        }
    }


    public void P_Die()
    {
       if(DieCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
