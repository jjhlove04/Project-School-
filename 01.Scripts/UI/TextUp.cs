using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUp : MonoBehaviour
{
    private Text text;
    public string str;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
