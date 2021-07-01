using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerInput playerInput;
    public GameObject coin;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("coin");
            ScoreManager.CoinScore += 100;
            playerInput.PlayerEXP += 1000;
        }
        
    }
}