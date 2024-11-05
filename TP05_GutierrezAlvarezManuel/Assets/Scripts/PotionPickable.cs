using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickable : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    public AudioSource soundInvulnerable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundInvulnerable.Play();
            playerHealth.StartInvulnerability();
            gameObject.SetActive(false);
        }
    }
}
