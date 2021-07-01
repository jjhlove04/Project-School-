using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private float enemySpeed = 3f; //적 이동속도
    public GameObject playetPos; //타겟의 위치
    public GameObject HitBox;
    public float findDistance = 2f; //감지 범위
    public float chaseDistance = 1.2f; //감지 범위
    public float attackDistance = 0.7f; //공격 범위
    public float minX, maxX;
    public Transform currentPos; //현재 위치
    SpriteRenderer renderer;
    public bool isPatroling = false;
    public bool isChasing = false;
    public bool isAttack = false;

    Animator animator;
    Rigidbody2D rigid;
    void Start()
    {
        //Patrol();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPatroling)
        {
            StartCoroutine(MoveTime());
        }
        if(findDistance > transform.position.x - playetPos.transform.position.x)
        { 
            Debug.Log("Chase");
            isChasing = true;
        }
        if(isChasing)
        {
            Debug.Log("Chasing");

            Chasing();
        }
        
        Move();
        // remainDis = Mathf.Abs(transform.position.x - activePos);
        // if (remainDis <= 0)
        // {
        //     Patrol();
        //     if (!isPatroling)
        //     {
        //         StartCoroutine(patroling());
        //     }
        // }



        //currentPos.position = transform.position;
    }


    //랜덤이동(패트롤개념)
    float activePos;
    float randomX;
    float dir = 1;
    float remainDis;

    // IEnumerator patroling()
    // {
    //     isPatroling = true;
    //     transform.position = Vector3.MoveTowards(transform.position,
    //     new Vector3(activePos, transform.position.y, transform.position.z),
    //     enemySpeed * Time.deltaTime);
    //     yield return new WaitForSeconds(1f);
    //     isPatroling = false;
    // }
    // public void Patrol()
    // {
    //     randomX = Random.Range(5, 10) * dir;
    //     dir *= -1;
    //     activePos = transform.position.x + randomX;

    // }
    //이동
    IEnumerator MoveTime()
    {
        isPatroling = true;
        yield return new WaitForSeconds(Random.Range(2, 4));
        dir *= -1;
        yield return new WaitForSeconds(1f);
        isPatroling = false;

    }
    public void Move()
    {
        rigid.velocity = new Vector2(dir, rigid.velocity.y);
        animator.SetInteger("State", 1);
        renderer.flipX = dir < 0;
        float clampX = Mathf.Clamp(transform.position.x,minX,maxX);
        transform.position = new Vector3(clampX,transform.position.y,transform.position.z);
        if(transform.position.x > maxX)
        {
            dir *= -1;
        }
        // if(Vector2.Distance(transform.position  , playetPos.position) > findDistance)
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, playetPos.position, enemySpeed);
        //     if(currentPos >)
        // }
    }
    //추격
    public void Chasing()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, playetPos.transform.position,3f);

    }

    //공격
    public void Attack()
    {

    }
}
