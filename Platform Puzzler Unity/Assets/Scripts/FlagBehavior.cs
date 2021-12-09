using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlagBehavior : MonoBehaviour
{
    public int sceneIndex;
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
        //Load next scene until we get to the last level
        if(sceneIndex != 5)
        {
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Flag");
        }

        //Displays winning text after completeing Level 5
        else
        {
            LevelWin.text = "You win!";
            //Pause game
            Time.timeScale = 0;
        }


    }
}
