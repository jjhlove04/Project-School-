using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    Text coinCount;
    void Start()
    {
        coinCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = ScoreManager.CoinScore.ToString();
    }
}
