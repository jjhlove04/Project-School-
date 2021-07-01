using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider hpBar;
    PlayerInput playerInput;
    private float maxHp = 300;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        hpBar.value =  playerInput.PlayerHP / maxHp ;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = playerInput.PlayerHP / maxHp;
    }
}
