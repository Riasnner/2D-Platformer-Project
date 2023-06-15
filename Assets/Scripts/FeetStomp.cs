using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeetStomp : MonoBehaviour
{
    [SerializeField] private ParticleSystem explode;
    [SerializeField] private AudioSource deathSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            deathSoundEffect.Play();
            explode.Play();
        }
    }

}
