using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public float holdTimer = 2.0f; // 8-10 seems to be comfy for editor | BUILD: needs to be about 2 
    public Grid tileset;
    private bool hold = false;
    private Vector4 light_blue = new Vector4(0.2f, 0.8f, 0.9f, 1f);
    private Vector4 dark_blue = new Vector4(0.2f, 0.4f, 0.9f, 1f);
    private Vector3 mousePosition;
    private float currHold = 0.0f;

    void Start() { 
        Cursor.visible = false;  // turn off the player's default cursor
        Cursor.lockState = CursorLockMode.Confined; // lock the cursor to the game screen
    }
    void Update()
    {
        // move gameObject with the cursor
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // if mouse IS CLICKED
        if(Input.GetMouseButton(0)){
            // check how long button is held for; above is PER FRAME call
            currHold += 0.1f;
            if(currHold >= holdTimer) { // if held timer is above the threshold; execute holding logic
                //Debug.Log(tileset.LocalToCell(transform.localPosition));
                //Debug.Log(transform.localPosition);
                SnapToGridPosition(0.5f);
                this.GetComponent<Collider2D>().enabled = true;
                this.GetComponent<Renderer>().material.color = dark_blue;
                hold = true;
            }
        } else { transform.position = mousePosition; } // else have platform follow cursor movement

        // mouse button is released
        if(Input.GetMouseButtonUp(0)){
            //Debug.Log(currHold + " held time");
            // check if player held; if not then flip the platform
            if(hold == false) { transform.eulerAngles += new Vector3(0, 0, 90); }
            // on release reset our variables and make the platform not collidable & light blue
            hold = false;
            currHold = 0.0f;
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<Renderer>().material.color = light_blue;
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

    // threshold is a temp variable similar to the holdtimer implemented above
    // threshold calculates how close the user is to a certain tile on the map
    // this *should* fix most cases where the player cursor is slightly above other platforms
    // while trying to cover a gap
    // TO DO: Smoother way to cross a gap?
    void SnapToGridPosition(float threshold){
        Vector3Int cellPos = tileset.LocalToCell(transform.localPosition);
        Vector3 diffVector = cellPos - transform.localPosition;
        // if the difference is small enough we snap the player cursor
        if(diffVector.magnitude < threshold && diffVector.magnitude > -threshold){
            Debug.Log("Snapped Player");
            transform.localPosition = tileset.GetCellCenterLocal(cellPos);
        }
    }
}
