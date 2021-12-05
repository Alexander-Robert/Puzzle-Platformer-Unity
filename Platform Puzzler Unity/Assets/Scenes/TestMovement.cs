using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public bool dir = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transform = this.GetComponent<Transform>();
        var position = transform.position;
        position.x += this.speed * Time.deltaTime;
        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var transform = this.GetComponent<Transform>();
        var position = transform.position;
        position.x -= this.speed * Time.deltaTime;
        transform.position = position;
    }

}
