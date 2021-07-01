using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public enum TitleState
{
    START,
    OPTION,
    EXIT
}

public class StartTitle : MonoBehaviour
{
    int index = 0;
    public Transform TitleText;
    public Transform start;
    public Transform option;
    public Transform option2;
    public Transform exit;
    public TitleState state;
    float time = 0f;
    float F_time = 1f;
    public Image Panel;
    public Animator player;

    Sequence Title;
    // Start is called before the first frame update]
    private void Awake()
    {
        
    }
    void Start()
    {
        option2.transform.localScale = Vector3.zero;
        option.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        exit.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartTitle1();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            index -= 1;
            if (index < 0)
            {
                index = 0;
            }
            Debug.Log(index);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            index += 1;
            if (index >= 3)
            {
                index = 2;
            }
            Debug.Log(index);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                StartCoroutine(startMenu());
                StartCoroutine(FadeFlow());
                
            }
            if(index == 1)
            {
                option2.DOScale(new Vector3(1,1,1),1);
            }
        }
        NextSelect();
    }

    public void StartTitle1()
    {

        Title.Kill();

        Title = DOTween.Sequence();

        Title.Append(start.DOLocalMoveX(0, 0.5f));
        Title.Append(option.DOLocalMoveX(425, 0.5f));
        Title.Append(exit.DOLocalMoveX(825, 0.5f));

    }
    public void NextSelect()
    {
        
        if (index == 0)
        {
            start.DOScale(new Vector3(1, 1, 1), 1);
            start.DOLocalMoveX(0, 1);
            option.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            option.DOLocalMoveX(425, 1);
            exit.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            exit.DOLocalMoveX(825, 1);
        }
        if (index == 1)
        {
            start.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            start.DOLocalMoveX(-425, 1);
            option.DOScale(new Vector3(1, 1, 1), 1);
            option.DOLocalMoveX(0, 1);
            exit.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            exit.DOLocalMoveX(425, 1);
        }
        if (index == 2)
        {
            start.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            start.DOLocalMoveX(-825, 1);
            option.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1);
            option.DOLocalMoveX(-425, 1);
            exit.DOScale(new Vector3(1, 1, 1), 1);
            exit.DOLocalMoveX(0, 1);
            

        }

    }
    public void CloseTab()
    {
        option2.DOScale(new Vector3(0,0,0),1);
    }
   
    IEnumerator startMenu()
    {
        player.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator FadeFlow()
    {
        yield return new WaitForSeconds(1);

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

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Ingame");


        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;

    }
}

