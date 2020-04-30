using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIElement : MonoBehaviour
{
    public Text lifeText;
    private PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            lifeText.text = "Vie : " + player.life.ToString();
        }
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}


