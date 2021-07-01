using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillMove : MonoBehaviour
{
    PlayerInput player;
    EnemyAi enemy;
    public float skillDamage = 0.1f;
    public int skillSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerInput>();
        Destroy(this.gameObject, 3);
        enemy = FindObjectOfType<EnemyAi>();
    }
    void Update()
    {

        transform.Translate(new Vector3(skillSpeed * Skill.skillDirection, 0, 0) * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        enemy.enemyHp -= skillDamage;
        Debug.Log(enemy.enemyHp);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
