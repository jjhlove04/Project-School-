using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Slash : MonoBehaviour
{
    PlayerInput player;
    EnemyAi enemy;
    SpriteRenderer renderer;
    
    Skill skillDir;
    public float skillDamage = 100;

    public int skillSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        enemy = FindObjectOfType<EnemyAi>();
        skillDir = FindObjectOfType<Skill>();
        player = FindObjectOfType<PlayerInput>();
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Skill.skillDirection <= 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }
        skillDir.SkillSet();
        transform.Translate(new Vector3(skillSpeed * Skill.skillDirection, 0, 0) * Time.deltaTime);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy.enemyHp -= skillDamage;
            
        }

    }
}
