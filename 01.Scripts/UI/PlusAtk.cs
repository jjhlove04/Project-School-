using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusAtk : MonoBehaviour
{
    Text AttackText;
    // Start is called before the first frame update
    void Start()
    {
        AttackText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackText.text = GameManager.Attack.ToString();
    }
}
