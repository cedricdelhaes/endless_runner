using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameBehaviour : MonoBehaviour
{
    private PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.life <= 0)
            SceneManager.LoadScene("GameOver");
    }
}
