using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    
    public Transform GameOverPanel;
    public Transform GameClearPanel;
    PlayerInput playerInput;
    BossMonster Boss;
    public Transform EnterPos;
    public Transform Enter2Pos;
    public Image miniMap;
    public GameObject act1;
    public GameObject act2;
    public PlayerInput player;
    public Image Panel;
    public GameObject CoinUI;
    float time = 0f;
    float F_time = 1f;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeFlow());
    }
    public void FadeStart()
    {
        StartCoroutine(FadeFlow());
    }

    private void Start()
    {   
        
        Boss = FindObjectOfType<BossMonster>();
        GameOverPanel.localScale = Vector3.zero;
        GameClearPanel.localScale = Vector3.zero;
        player = FindObjectOfType<PlayerInput>();
    }

    private void Awake()
    {

    }

    private void Update()
    {
        Game();
    }
    public void Game()
    {
        if (player.PlayerHP <= 0)
        {
            GameOverPanel.DOScale(new Vector3(1, 1, 1), 0.5f);
        }
        
    }

    public IEnumerator FadeFlow()
    {

        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        player.gameObject.transform.position = EnterPos.position;
        CoinUI.SetActive(false);
        act1.SetActive(false);

        yield return new WaitForSeconds(2f);
        Debug.Log("좆댐");
        act2.SetActive(true);
        CoinUI.SetActive(true);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.7f);

        yield return null;
    }
}
