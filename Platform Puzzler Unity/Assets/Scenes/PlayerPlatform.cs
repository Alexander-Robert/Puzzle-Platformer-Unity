using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    private Vector3 mousePosition;

    void Start() { Cursor.visible = false; }
    void Update()
    {
        this.GetComponent<Collider>().isTrigger = true;
        // move gameObject with the cursor
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        // if mouse IS CLICKED
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("CLICK");
            transform.eulerAngles += new Vector3(0, 0, 90);
        } else if(Input.GetKey(KeyCode.Mouse1)){ // change to LEFTmouse is HELD
            Debug.Log("HELD");
            this.GetComponent<Collider>().isTrigger = false; 
        }

        // allow esc to quit the game
        // Let anyone end the game with the 'esc' Key in editor or in the build
        if(Input.GetKeyDown(KeyCode.Escape)){
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
