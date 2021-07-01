using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Shop : MonoBehaviour
{
    public GameObject target;
    PlayerInput playerInput;
    ScoreManager scoreManager;
    public BoxCollider2D range;
    public Transform aPanel;
    public Transform WarningPanel;
    Sequence apanelScale;
    bool first = true;
    Sequence WarningpanelScale;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        aPanel.transform.localScale = Vector3.zero;
        WarningPanel.transform.localScale = Vector3.zero;
    }

    private void OnMouseDown()
    {
        range.enabled = false;
        playerInput.isAttack = false;
        playerInput.isMoving = false;
        playerInput.isJumping = false;
        apanelScale.Kill();
        if(first)
        {
            ScoreManager.CoinScore += 1000;
            first = false;
        }
        

        apanelScale = DOTween.Sequence();


        apanelScale.Append(aPanel.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.4f));
        apanelScale.Append(aPanel.DOScale(new Vector3(1f, 1f, 1f), 0.4f));

    }

    public void CloseTab()
    {
        
        playerInput.isMoving = true;
        playerInput.isJumping = true;
        playerInput.isAttack = true;
        playerInput.ATKCheck();
        apanelScale.Append(aPanel.DOScale(new Vector3(0, 0, 0), 0.4f));
        range.enabled = true;
        
    }
    public void BuyPotion()
    {
        

        if(ScoreManager.CoinScore >= 1000 && playerInput.jumpCount <3)
        {
            
            ScoreManager.CoinScore -= 1000;
            playerInput.jumpRimit++;
        }
        else
        {
        WarningpanelScale.Kill();
        WarningpanelScale = DOTween.Sequence();


        WarningpanelScale.Append(WarningPanel.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.9f));
        WarningpanelScale.Append(WarningPanel.DOScale(new Vector3(0, 0, 0), 0.8f));
        

        }        
    }
}
