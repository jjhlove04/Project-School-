using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    private PlayerInput player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<PlayerInput>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
            player.Grounded = true;
            player.jumpCount = 0;
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        player.Grounded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
