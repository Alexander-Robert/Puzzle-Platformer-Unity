using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagBehavior : MonoBehaviour
{
    public Text LevelWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        LevelWin.text = "You win!";
        Debug.Log("Flag");
        //Pause game
        Time.timeScale = 0;

    }
}
