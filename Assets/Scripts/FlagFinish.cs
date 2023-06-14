using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagFinish : MonoBehaviour
{
    private AudioSource finishEffect;
    private bool levelCompleted = false;

    public GameOverScreen gameOverScreen;
    public PlayerMovement playerMovement;
    void Start()
    {
        finishEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishEffect.Play();
            levelCompleted = true;
            gameOverScreen.Setup();
            playerMovement.StopPlayer();
        }
    }
}
