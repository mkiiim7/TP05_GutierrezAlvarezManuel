using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickable : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Potion");
            playerHealth.StartInvulnerability();
            gameObject.SetActive(false);
        }
    }
}
