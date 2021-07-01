using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public GameObject coin;
    public GameObject DamageText;
    public Transform TextPos;
    public float enemyHp = 1000;
    public float enemyAttck = 10;
    public GameObject Hitbox;
    float enemySpeed = 3;
    Animator animator;
    PlayerInput playerInput;
    Vector3 movement;
    HitDamageShow hit;
    skillMove skill;
    bool isWall;
    int movementFlag = 0;
    SpriteRenderer renderer;
    bool isMoving;
    bool StopMoving;
    bool stun;
    Vector3 moveVelocity = Vector3.zero;


    void Start()
    {
       
        playerInput = FindObjectOfType<PlayerInput>();
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeMovement());
        renderer = GetComponent<SpriteRenderer>();
        isMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHp <= 0)
        {
            StartCoroutine(Die());

        }

        if (isMoving)
        {
            Move();
        }
        else
        {
            moveVelocity = Vector3.zero;
            StartCoroutine(HitDelay());
        }

    }

    IEnumerator Die()
    {
        
        moveVelocity = Vector3.zero;
        animator.SetTrigger("Die");
        movementFlag = 0;
        animator.SetBool("isMove", false);
        yield return new WaitForSeconds(1f);
        GameManager.BossCount = GameManager.BossCount+5;
        //Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        isMoving = false;
        playerInput.PlayerEXP += 1000;
        yield return new WaitForSeconds(1f);
        
    }
    void Move()
    {


        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            renderer.flipX = true;

        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            renderer.flipX = false;
        }
        if(!isMoving)
        {
            moveVelocity = Vector3.zero;
            StartCoroutine(HitDelay());
        }


        if(isMoving)
            transform.position += moveVelocity * enemySpeed * Time.deltaTime;
    }
    IEnumerator ChangeMovement()
    {
        if (isMoving)
        {
            movementFlag = Random.Range(0, 3);
            if (movementFlag == 0) //idle
            {
                animator.SetBool("isMove", false);
                moveVelocity = Vector3.zero;
            }
            else
            {
                animator.SetBool("isMove", true);
            }
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeMovement());
    }
    IEnumerator HitDelay()
    {
        animator.SetBool("isMove", false);
        yield return new WaitForSeconds(1f);
        
        isMoving = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Wall") || other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            animator.SetBool("isMove", false);
            isMoving = false;
            StartCoroutine(HitDelay());
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage" && this.gameObject.tag == "Enemy")
        {

            animator.SetTrigger("Hit");
            enemyHp -= GameManager.Attack;
            isMoving = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Skill" && this.gameObject.tag == "Enemy")
        {
            //Instantiate(DamageText, TextPos).FindObjectOfType<HitDamageShow>().textPro.text = skill.skillDamage.ToString();
            animator.SetTrigger("Hit");
            isMoving = false;
            animator.SetBool("isMove", false);
            StartCoroutine(HitDelay());
        }
    }
    public void CoinCreat()
    {
        Instantiate(coin, transform.position,Quaternion.identity);
    }
    public void DeleteMob()
    {
        Destroy(this.gameObject);
    }

}