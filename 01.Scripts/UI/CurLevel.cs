using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurLevel : MonoBehaviour
{
    Text curLevel;
    PlayerInput playerInput;
    void Start()
    {
        curLevel = GetComponent<Text>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        curLevel.text = playerInput.PlayerLevel.ToString();
        
    }
}
