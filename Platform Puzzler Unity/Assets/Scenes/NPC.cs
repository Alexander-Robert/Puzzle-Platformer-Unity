using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = -10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float direction = Input.GetAxis("Horizontal");
        var transform = this.GetComponent<Transform>();
        var position = transform.position;
        //position.x += direction * this.speed * Time.deltaTime;
        position.x += this.speed * Time.deltaTime;
        transform.position = position;

    }

    //OnTrigger events should only be called given the two side edge colliders attached to the NPC
    //AKA (the player's sides hit something)
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.speed *= -1; //i.e. hitting the side of a platform/wall has the player change directions

        //catgorizing the type of objects through tags helps us modify the behavior when triggered by the NPC
        // switch (other.gameObject.tag)
        // {
        //     case "Platform":
        //         this.speed *= -1; //i.e. hitting the side of a platform/wall has the player change directions
        //         break;
        //     default:
        //         Debug.Log("Unhandled tag given: " + other.gameObject.tag);
        //         break;
        // };

    }
}
