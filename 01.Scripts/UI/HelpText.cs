using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpText : MonoBehaviour
{
    
    [TextArea]
    public string text;
    public Transform position;

    private bool isActive = false;

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !isActive){
            TextEffect.SetText(text, position);
            isActive = true;
            
        }
    }
}
 