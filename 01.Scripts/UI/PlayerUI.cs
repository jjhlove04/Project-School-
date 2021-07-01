using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject TargetPos;
    public Text CurLevel;
    PlayerInput playerInput;
    
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.transform.position = Vector3.Lerp(ui.transform.position,
            Camera.main.WorldToScreenPoint(TargetPos.transform.position),
            Time.deltaTime * 15f);
    }
}
