using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    public FadeIn fade;
    
    PlayerInput player;


    private void Update()
    {
        player = GetComponent<PlayerInput>();
    }
    void OnCollisionEnter(Collision other)
    {
         
        //저희 안마방 에이스 김건범선수 준비해주세용~
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        fade.FadeStart();
        
        
    }

    
}
