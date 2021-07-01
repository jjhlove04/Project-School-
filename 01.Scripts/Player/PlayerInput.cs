using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public AudioClip Run;
    public AudioClip Attack;
    public AudioClip Skill;
    AudioSource audioSource;
    GameManager gm;
    public GameObject RHitBox;
    public GameObject LHitBox;
    public GameObject Foot;
    public GameObject Skill2Pos;
    public GameObject Skill2;
    public float PlayerHP = 300;

    Vector3 playerMove = new Vector3();
    
    public int jumpCount = 0;
    public int animStateRun;
    public int jumpRimit = 2;
    public float PlayerSpeed = 5f;
    public float PlayerJump = 6f;
    public float PlayerEXP = 0;
    public float Skill2Speed = 5;
    public int PlayerLevel = 0;
    public float AtkCol = 1f;
    private int rank = 0;
    public float curEXP = 0;
    float coolTime = 0;
    Rigidbody2D rigidbody;
    Vector3 moveMent;
    EnemyAi enemy;
    BossMonster Boss;
    public bool isMoving = false;
    public bool isJumping = false;
    public bool isAttack = true;
    public bool Grounded = false;
    bool ATKCool;
    float Combo1 = 0;
    Animator animator;
    BoxCollider2D Hitbox;

    public SpriteRenderer Renderer;
    void Start()
    {
        Boss = FindObjectOfType<BossMonster>();
        audioSource = GetComponent<AudioSource>();
        Hitbox = GetComponent<BoxCollider2D>();
        isMoving = true;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        enemy = FindObjectOfType<EnemyAi>();

    }

    public void ATKCheck()
    {
        ATKCool = false;
    }
    void Update()
    {
        Debug.Log(isMoving);
        AtkCol -= Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0) && !ATKCool)
        {
            ATKCool = true;
            Attackk();
        }

        animator.SetBool("Grounded", Grounded);
        //GroundCheck();
        animator.SetFloat("AirSpeedY", rigidbody.velocity.y);
        if (Input.GetButtonDown("Jump") && jumpCount < jumpRimit)
        {
            animator.SetTrigger("Jump");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, PlayerJump);
            jumpCount++;
        }
        if (isAttack == false)
        {
            return;
        }

        Die();
        LevelUp();
    }
    private void FixedUpdate()
    {
        Move();

    }


    public void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        

        if (!isMoving)
        {

            animator.SetInteger("AnimState", 0);
            return;
        }
        else
        {


            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                
                moveVelocity = Vector3.right * Input.GetAxisRaw("Horizontal");
                Renderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
                animator.SetInteger("AnimState", 1);
                
                
                animator.SetBool("Grounded", true);
                isMoving = true;
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }
        }

        transform.position += moveVelocity * PlayerSpeed * Time.deltaTime;
    }
    public void LevelUp()
    { //playerEXP = 5000;

        for (int i = PlayerLevel; i <= PlayerEXP / 1000; i++)
        {

            PlayerLevel++;
            switch (PlayerLevel)
            {
                case 5:
                    GameManager.PlayerRank = 1;
                    GameManager.Attack += 10;
                    GameManager.Speed += 0.1f;

                    break;
                case 10:
                    GameManager.PlayerRank = 2;
                    GameManager.Attack += 12;
                    GameManager.Speed += 0.2f;
                    break;
                case 15:
                    GameManager.PlayerRank = 3;
                    GameManager.Attack += 14;
                    GameManager.Speed += 0.3f;
                    break;
                case 20:
                    GameManager.PlayerRank = 4;
                    GameManager.Attack += 16;
                    GameManager.Speed += 0.35f;
                    break;
                case 25:
                    GameManager.PlayerRank = 5;
                    GameManager.Attack += 20;
                    GameManager.Speed += 0.4f;
                    break;
                case 30:
                    GameManager.PlayerRank = 6;
                    GameManager.Attack += 30;
                    GameManager.Speed += 0.85f;
                    break;
            }
        }
    }
    public void Jump()
    {
        if (!isJumping)
        {
            return;
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, PlayerJump);

        isJumping = false;

    }
    public void remakeATKgogo()//히트박스 실행
    {

        StartCoroutine(remakeATK());

    }
    IEnumerator remakeATK() //히트박스
    {
        if (Renderer.flipX)
        {
            LHitBox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            LHitBox.SetActive(false);
        }
        else
        {
            RHitBox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            RHitBox.SetActive(false);
        }

    }
    void Attackk() //공격
    {
        if (isAttack)
        {
            
            animator.SetTrigger("Attack1");
            isMoving = false;
            animator.SetFloat("Combo", Combo1);
            Combo1++;
            if (Combo1 == 3)
            {
                Combo1 = 0;
            }
             
            
        }
    }


    public void State() //무브 전환 수동
    {

        isMoving = true;
       
    }

    void Die() //죽었을때
    {
        if (PlayerHP <= 0)
        {
            animator.SetBool("Die", true);
            isMoving = false;
            isAttack = false;
            isJumping = false;

        }


    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "BossBody")
        {
            Boss.BossHp -= GameManager.Attack;
        }
        if(other.gameObject.tag == "BossHitBox")
        {
            PlayerHP -= Boss.BossATK;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //적한테 피격
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerHP -= enemy.enemyAttck;

        }
        
    }
    void PlayMusic1()//달리기
    {
        AudioPlay(1);
    }
    void PlayMusic2()//공격
    {
        AudioPlay(2);
    }
    void PlayMusic3()//스킬 
    {
        AudioPlay(3);
    }

    public void Skill2Play()
    {
        Instantiate(Skill2,Skill2Pos.transform.position,Quaternion.identity);
    }
    
    public void AudioPlay(int AudioNum)
    {
        switch(AudioNum)
        {
            case 1:
            audioSource.clip = Run;
            break;
            case 2:
            audioSource.clip = Attack;
            break;
            case 3:
            audioSource.clip = Skill;
            break;

        }
        audioSource.Play();
    }
    
    
    
}



