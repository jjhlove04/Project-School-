using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill2Move : MonoBehaviour
{
    PlayerInput player;
    EnemyAi enemy;
    BossMonster Boss;
    public float skillDamage = 1;
    public int skillSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        Boss = FindObjectOfType<BossMonster>();
        player = FindObjectOfType<PlayerInput>();
        Destroy(this.gameObject, 4);
        enemy = FindObjectOfType<EnemyAi>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        enemy.enemyHp -= skillDamage;
        Debug.Log(enemy.enemyHp);
        if(other.gameObject.tag=="BossBody")
        {
            Boss.BossHp -= (skillDamage);
        }
    }
}
