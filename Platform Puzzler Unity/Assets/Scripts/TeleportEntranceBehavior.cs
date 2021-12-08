using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEntranceBehavior : MonoBehaviour
{
    private GameObject NPC;
    public Transform teleporterExitPosition;
    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.Find("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var NPCTransform = NPC.GetComponent<Transform>();
        NPCTransform.position = teleporterExitPosition.position;
    }
}
