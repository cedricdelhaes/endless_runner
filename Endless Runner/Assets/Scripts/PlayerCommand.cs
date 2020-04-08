using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    public GameObject area;

    public float vSpeed, hSpeed;

    // Update is called once per frame
    void Update()
    {
        OnPlayerTriggerKey();
    }

    private void OnPlayerTriggerKey()
    {
        //If player request up or down calculate new position
        Vector3 newPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            newPosition = transform.position + Vector3.up * vSpeed;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            newPosition = transform.position - Vector3.up * vSpeed;
        }

        //if new position are inside the area allow update position
        if(newPosition.y < area.GetComponent<Area>().y/2 && newPosition.y > -area.GetComponent<Area>().y/2)
            transform.position = newPosition;
    }
}
