
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class NagaMove : MonoBehaviour
{
    [SerializeField] GameObject moveOBJ;
    [SerializeField] GameObject[] body;
    [SerializeField] float movePower;
    [SerializeField] GameObject dieParticle;

    [SerializeField] LayerMask BossLayer;
    [SerializeField] Transform PlayerTrm;

    Vector2 movePos;
    [SerializeField] Vector2 nextMovePos;

    [SerializeField] float circleR = 10f;
    [SerializeField] float deg;
    [SerializeField] float circleSpeed;
    bool circleSizeDown = false;

    private int nagaSize = 0;
    private bool die = false;
    private bool isPattern = false;

    private void Awake()
    {
        nagaSize = body.Length;
    }

    private void Update()
    {
        if (die == false)
        {
            Move();
            if ((body[0].transform.rotation.z == 0 && isPattern == false) || isPattern == false)
            {
                int rand = Random.Range(1, 10); // 나중에 11로 변경
                switch (rand)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        StartCoroutine("PatternCircleStart", false);
                        break;
                    case 8:
                    case 9:
                        StartCoroutine("PatternCircleStart", true);
                        break;
                    case 10:
                        Debug.Log("We don't have Skill Pattern");
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine("PatternCircleStart");
            }

            if (nagaSize <= 3)
            {
                StartCoroutine(Die());
            }

        }
    }




    private IEnumerator Die()
    {
        die = true;
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i] == null)
            {
                continue;
            }
            body[i].transform.DOShakePosition(100, 0.2f, 10, 90, false, true);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i] == null)
            {
                continue;
            }

            Instantiate(dieParticle, body[i].transform.position, Quaternion.identity);
            Destroy(body[i]);
            yield return new WaitForSeconds(0.3f);
        }
    }


    IEnumerator PatternCircleStart(bool isAttack = false)
    {
        isPattern = true;
        circleSizeDown = isAttack;
        movePower = 40f;
        circleR = 10;
        deg = body[0].transform.rotation.z;
        for (float i = 0; i < 8; i += Time.deltaTime)
        {
            Circle();
            yield return null;
        }
        movePower = 10;
        moveOBJ.transform.rotation = Quaternion.identity;
        circleSizeDown = false;
        isPattern = false;
    }

    private void Circle()
    {
        deg -= Time.deltaTime * movePower;
        if (circleSizeDown == true)
        {
            if (circleR < 4)
            {
                circleR = 0;
            }
            else
            {
                circleR -= Time.deltaTime * 0.8f;
            }

        }
        if (deg > 0)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            //moveOBJ.transform.position = PlayerTrm.transform.position + new Vector3(x, y);
            float dis = Vector2.Distance(moveOBJ.transform.position, PlayerTrm.position);
            moveOBJ.transform.DOMove(PlayerTrm.position + new Vector3(x, y), dis * 0.5f);
            moveOBJ.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
        }
        else
        {
            deg = 360;
        }
    }

    private void Move()
    {
        GameObject targetOBJ = null;
        nagaSize = body.Length;
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i] == null)
            {
                nagaSize--;
                continue;
            }
            if (i == 0)
            {

                targetOBJ = moveOBJ;
                Vector3 targetPos = -(body[i].transform.position - targetOBJ.transform.position).normalized;

                if (Vector2.Distance(targetOBJ.transform.position, body[i].transform.position) <= 0.5f)
                    continue;
                else
                {
                    body[i].transform.position += targetPos * Time.deltaTime * movePower;
                }

                Vector3 dir = body[i].transform.position - targetOBJ.transform.position;
                float angle = MathF.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                body[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            }
            else
            {
                if (body[i - 1] != null)
                {
                    targetOBJ = body[i - 1];
                }
                else
                {
                    for (int j = 2; j < body.Length; j++)
                    {
                        if (body[i - j] != null)
                        {
                            targetOBJ = body[i - j];
                            break;
                        }
                    }
                }

                Vector3 targetPos = -(body[i].transform.position - targetOBJ.transform.position).normalized;

                if (Vector2.Distance(targetOBJ.transform.position, body[i].transform.position) <= 1.2f)
                    continue;
                else
                {
                    body[i].transform.position += targetPos * Time.deltaTime * movePower;
                }

                Vector3 dir = body[i].transform.position - targetOBJ.transform.position;
                float angle = MathF.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                body[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

    }

}