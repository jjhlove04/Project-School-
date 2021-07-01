using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static int  PlayerRank;
    [SerializeField]
    public static int Attack;
    public static float Speed;
    public static int BossCount;
    PlayerInput playerInput; //플레이어의 상태를 관리
    EnemyAi enemyAi; //적의 행동상태를 관리
    EnemyState enemyState; //적의 행동을 관리
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        enemyState = FindObjectOfType<EnemyState>();
        enemyAi = FindObjectOfType<EnemyAi>();
        PlayerRank = 1;
        Attack = 100;
        Speed = 5;
        BossCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
