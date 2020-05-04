using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{

    public bool drawnDirection;
    private Vector3 mousePosition;

    public Animator playerAnimation;


    public GameObject area;
    public float vSpeed, hSpeed;

    private PlayerBehaviour _playerBehaviour;
    public PlayerBehaviour playerBehaviour
    {
        get
        {
            if (_playerBehaviour == null)
                _playerBehaviour = GetComponent<PlayerBehaviour>();

            return _playerBehaviour;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnPlayerTriggerKey();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //keep position inside Area
        mousePosition.x = mousePosition.x > area.GetComponent<Area>().x / 2 ? area.GetComponent<Area>().x / 2 : mousePosition.x;
        mousePosition.x = mousePosition.x < -area.GetComponent<Area>().x / 2 ? -area.GetComponent<Area>().x / 2 : mousePosition.x;
        mousePosition.y = mousePosition.y > area.GetComponent<Area>().y / 2 ? area.GetComponent<Area>().y / 2 : mousePosition.y;
        mousePosition.y = mousePosition.y < -area.GetComponent<Area>().y / 2 ? -area.GetComponent<Area>().y / 2 : mousePosition.y;
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;

        /*Give animation data to display sprite*/
        playerAnimation.SetInteger("player_x", (int)direction.x);
        playerAnimation.SetInteger("player_y", (int)direction.y);

        transform.Translate(direction * vSpeed * Time.deltaTime, 0);

    }

    private void OnPlayerTriggerKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playerBehaviour.SwitchSpirit();
        //Right click left click power ?
    }

    private void OnDrawGizmos()
    {
        if (drawnDirection && mousePosition != null)
            Gizmos.DrawLine(mousePosition, transform.position);
    }
}
