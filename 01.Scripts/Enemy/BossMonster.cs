using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class BossMonster : MonoBehaviour
{
    public Image sprite;
    public Transform x_mark;
    Animator animator;
    public Transform GameClearPanel;
    public Transform Warning1;
    public Transform Warning2;
    public GameObject Skillpos;
    public GameObject Skill1;
    public Transform HpBar;
    public float BossHp = 3000;
    public float BossATK = 100;
    public Slider BosshpBar;
    public Transform BossPos;
    bool BossShow = true;
    bool BossState = false;
    float cooltime = 4;
    float BossSkill2Cool = 7;
    float BossSkill1Cool = 2;
    private float maxHp = 5000;
    public int movementFlag;

    // Start is called before the first frame update
    void Start()
    {
        x_mark.localScale = Vector3.zero;
        GameClearPanel.localScale = Vector3.zero;
        BosshpBar.value = BossHp / maxHp;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        cooltime -= Time.deltaTime;
        BossSkill2Cool -= Time.deltaTime;
        BossSkill1Cool -= Time.deltaTime;

        if (BossState)
        {
            BossPattern();
        }
        if (BossHp <= 0)
        {
            DieBoss();
        }



        BosshpBar.value = BossHp / maxHp;
        if (GameManager.BossCount >= 45 && BossShow)
        {
            StartCoroutine(BossCreat());
            BossShow = false;
        }
    }

    IEnumerator BossCreat()
    {
        Warning1.DOLocalMoveX(-4000,10);

        Warning2.DOLocalMoveX(-4000,10);
        HpBar.DOLocalMoveY(-550, 6);
        BossPos.DOLocalMoveX(116, 10);
        yield return new WaitForSeconds(6);
        BossState = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Damage")
        {
        BossHp -= GameManager.Attack;
            
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Skill2")
        {
            BossHp -= Skill.skill2Damage;
        }
    }
    public void GameClr()
    {
        
        GameClearPanel.DOScale(new Vector3(1, 1, 1), 0.1f);    
        StartCoroutine(BossRemove());
    }
    public IEnumerator BossRemove()
    {
        
        yield return new WaitForSeconds(1);
        sprite.color = new Color(67,67,67,100);
        x_mark.DOScale(new Vector3(1,1,1), 0.7f);
    }
    void BossPattern()
    {
        if (cooltime <= 0)
        {
            movementFlag = Random.Range(0, 3);
            cooltime = 4;
        }

        if (movementFlag == 0)
        {

        }
        if (movementFlag == 1 && BossSkill1Cool <= 0)
        {
            animator.SetTrigger("Skill1");
            BossSkill1Cool = 2;
        }
        if (movementFlag == 2 && BossSkill2Cool <= 0)
        {
            animator.SetTrigger("Skill2");
            BossSkill2Cool = 7;
        }
        if (BossSkill2Cool > 0 && movementFlag == 2)
        {

        }
    }

    public void CallSign()
    {
        Debug.Log("준협핑신");
    }

    void DieBoss()
    {
        animator.SetBool("Die", true);
        BossState = false;
    }

    public void Skill1MadeBoss()
    {
        Instantiate(Skill1, new Vector3(Skillpos.transform.position.x, Skillpos.transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, -60.08f)));
    }
}
