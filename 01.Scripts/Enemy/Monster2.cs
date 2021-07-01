using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{ public GameObject coin;
    public GameObject DamageText;
    public Transform TextPos;
    public float enemyHp = 1000;
    public float enemyAttck = 20;
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
    bool isLeft;
    Vector3 moveVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = FindObjectOfType<PlayerInput>(); 
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0)
        {
            StartCoroutine(Die());
        }
    }


    void Move()
    {
        if(isMoving)
        {
            animator.SetBool("Move", true);
            if(isLeft)
            {
                
            }
        }
    }

    IEnumerator Die()
    {
        GameManager.BossCount += 3;
        moveVelocity = Vector3.zero;
        animator.SetTrigger("Die");
        movementFlag = 0;
        animator.SetBool("isMove", false);
        yield return new WaitForSeconds(1f);
        Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        isMoving = false;
        playerInput.PlayerEXP += 1000;
        yield return new WaitForSeconds(1f);

    }
    
}
