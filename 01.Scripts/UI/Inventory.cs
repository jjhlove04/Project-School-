using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    GameManager gm;
    Skill skill;
    public Text[] ActRankNm;

    public Image[] playerRankImage;

    PlayerInput player;
    public Transform Panel;
    Sequence panelScale;

    bool isOpen = false;
    int OpenCount = 1;

    public void Awake()
    {
        player = FindObjectOfType<PlayerInput>();
        gm = FindObjectOfType<GameManager>();
        Panel.transform.localScale = Vector3.zero;
        skill = FindObjectOfType<Skill>();

    }

    public void ShowPlayerRank()
    {

        for (int i = 0; i < playerRankImage.Length; i++)
        {
            playerRankImage[i].enabled = (GameManager.PlayerRank - 1 == i);
            ActRankNm[i].enabled = (GameManager.PlayerRank - 1 == i);
        }

    }
    private void Update()
    {
        ShowPlayerRank();
        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenCount *= -1;
            StartPanelOn();
            isOpen = true;

        }
        //if(isOpen && OpenCount == 1)
        // {
        //     StartPanelOff();
        //     OpenCount = 0;
        // }
    }
    public void StartPanelOn()
    {
        if (OpenCount == -1)
        {
            panelScale.Kill();

            panelScale = DOTween.Sequence();
            player.isAttack = false;
            player.isMoving = false;
            player.isJumping = false;

            panelScale.Append(Panel.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.4f));
            panelScale.Append(Panel.DOScale(new Vector3(1f, 1f, 1f), 0.4f));
        }
        else
        {
            player.isAttack = true;
            player.isMoving = true;
            player.isJumping = true;
            player.ATKCheck();


            panelScale.Append(Panel.DOScale(new Vector3(0, 0, 0), 0.4f));


        }
    }
    public void StartPanelOff()
    {
        panelScale.Kill();

        panelScale = DOTween.Sequence();


        panelScale.Append(Panel.DOScale(new Vector3(0, 0, 0), 0.2f));
    }
    public void SetSkillNum()
    {
        skill.SkillNum = 1;
    }
    public void SetSkillNum2()
    {
        skill.SkillNum = 2;
    }
    public void SetSkillNum3()
    {
        skill.SkillNum = 3;
    }
}