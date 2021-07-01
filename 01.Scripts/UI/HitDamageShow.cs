using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HitDamageShow : MonoBehaviour
{
    public int speed = 2;
    public int alhpaSpeed = 2;
    public TextMeshPro textPro;
    Color alpha;
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        textPro = GetComponent<TextMeshPro>();
        alpha = textPro.color;
        Invoke("OnDestroy", 2);
        playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime,0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime *alhpaSpeed);
        textPro.color = alpha;
        textPro.text = GameManager.Attack.ToString();
    
    
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }


}
