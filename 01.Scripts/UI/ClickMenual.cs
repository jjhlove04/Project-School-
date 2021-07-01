using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickMenual : MonoBehaviour
{
    PlayerInput playerInput;
    public Transform Menu1;
    public Transform Menu2;
    public GameObject wall;

    Sequence MenualPop;

    void Start()
    {
        Menu1.transform.localScale = Vector3.zero;
        Menu2.transform.localScale = Vector3.zero;
        playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {        
        MenualPop.Kill();

        MenualPop = DOTween.Sequence();


        MenualPop.Append(Menu1.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.4f));
        
        MenualPop.Append(Menu1.DOScale(new Vector3(1f, 1f, 1f), 0.4f));
        Menu2.transform.localPosition = new Vector3(1600,0,0);
        playerInput.isJumping = false;
        playerInput.isAttack = false;
        playerInput.isMoving = false;

    }

    public void NextTab()
    {
        
        MenualPop.Append(Menu1.DOScale(new Vector3(0, 0, 0), 0.4f));
        MenualPop.Append(Menu2.DOLocalMoveX(0,1f));
        MenualPop.Append(Menu2.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.4f));
        MenualPop.Append(Menu2.DOScale(new Vector3(1f, 1f, 1f), 0.4f));
    }
    public void CloseTab()
    {
        MenualPop.Append(Menu1.DOScale(new Vector3(0, 0, 0), 0.4f));
        MenualPop.Append(Menu2.DOScale(new Vector3(0, 0, 0), 0.4f));
        playerInput.isJumping = true;
        playerInput.isAttack = true;
        playerInput.isMoving = true;
        playerInput.ATKCheck();
        Destroy(wall,2);
        
        
    }
}
