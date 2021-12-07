using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehavior : MonoBehaviour
{
    private GameObject player;
    //private GameObject player = GameObject.Find("NPC");;
    private float jumpHeight = 8f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("jump pad triggered!");
        var playerRigidbody = player.GetComponent<Rigidbody2D>();
        //add an upward vector to the player
        playerRigidbody.velocity = Vector2.up * jumpHeight;
        //gravity should do the rest!
    }
}
