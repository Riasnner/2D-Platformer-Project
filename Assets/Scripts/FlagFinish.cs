using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagFinish : MonoBehaviour
{
    private AudioSource finishEffect;
    public GameOverScreen gameOverScreen;
    public PlayerMovement playerMovement;
    private void Start()
    {
        finishEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishEffect.Play();
            gameOverScreen.Setup();
            playerMovement.StopPlayer();
        }
    }
}
