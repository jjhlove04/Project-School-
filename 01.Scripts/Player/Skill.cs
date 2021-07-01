using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image imageFill;
    Animator animator;
    PlayerInput player;
    public GameObject skill1;
    public GameObject skill2;
    public static float skill2Damage = 5;
    public float skillSpeed;
    public GameObject skillPos;
    public GameObject skill2PosR;
    public GameObject skill2PosL;
    public int SkillNum;
    float CoolTime = 0f;
    int count = 0;
    public float defaultCool = 5f;
    Vector3 moveVelocity = Vector3.zero;

    public static int skillDirection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerInput>();
    }
    void Update()
    {
        CoolTime -= Time.deltaTime;
        Skill1();
    }
    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CoolTime <= 0 && SkillNum == 1)
            {
                animator.SetTrigger("skill");
                player.isMoving = false;
                CoolTime = defaultCool;
            }
            if (CoolTime <= 0 && SkillNum == 2)
            {
                animator.SetTrigger("skill2");
                player.isMoving = false;
                CoolTime = defaultCool;

            }
        }
    }

    public void SkillSet()
    {
        if (player.Renderer.flipX)
        {
            skillDirection = -1;
        }
        else
        {
            skillDirection = 1;
        }
    }
    public void Tonedo()
    {
        Instantiate(skill1, new Vector3(skillPos.transform.position.x, skillPos.transform.position.y, 0),
        Quaternion.identity);
    }
    void MoveControll()
    {
        player.isMoving = true;
        player.isAttack = true;
    
    }
    void skill2Start()
    {
        if (player.Renderer.flipX)
        {
            Instantiate(skill2, new Vector3(skill2PosL.transform.position.x, skill2PosL.transform.position.y, 0),
            Quaternion.identity);
        }
        else
        {
            Instantiate(skill2, new Vector3(skill2PosR.transform.position.x, skill2PosR.transform.position.y, 0),
            Quaternion.identity);
        }

    }
}
