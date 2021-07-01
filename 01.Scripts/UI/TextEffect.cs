using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    PlayerInput player;
    public Text msgTextUI;
    Transform target;

    private static TextEffect instance;

    private Transform textTarget;
    private bool isTargetSet = false;
    Coroutine co = null;

    private void Awake()
    {
        instance = this;
    }

    public static void SetText(string msg, Transform pos)
    {
        instance.SetTextInstance(msg, pos);
    }

    public void SetTextInstance(string msg, Transform pos)
    {
        if(co != null)
            StopCoroutine(co);

        isTargetSet = true;
        textTarget = pos;
        co = StartCoroutine(typing(msg));
    }

    private void Update()
    {
        if (isTargetSet)
        {
            Vector3 textPos = Camera.main.WorldToScreenPoint(textTarget.position);

            msgTextUI.transform.position = textPos;
        }

    }

    IEnumerator typing(string msg)
    {
        msgTextUI.text = "";

        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i <= msg.Length; i++)
        {
            msgTextUI.text = msg.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1.5f);

        msgTextUI.text = "";
        isTargetSet = false;
    }

    // Update is called once per frame
}
